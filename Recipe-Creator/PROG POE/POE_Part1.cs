using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE
{
    internal class POE_Part1
    {
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
        public int ScaleAmount { get; set; }

        public string[] IngredientName { get; set; }

        public double[] oldIngredientQuan { get; set; }
        public double[] newIngredientQuan { get; set; }
        public double[] quantityRemainder { get; set; }

        public string[] oldUnits { get; set; }
        public string[] newUnits { get; set; }
        
        public string[] Steps { get; set; }

        public POE_Part1(int numIngredients, int numSteps)
        {
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            IngredientName = new string[numIngredients];
            oldIngredientQuan = new double[numIngredients];
            newIngredientQuan = new double[numIngredients];
            quantityRemainder = new double[numIngredients];
            oldUnits = new string[numIngredients];
            newUnits = new string[numIngredients];
            Steps = new string[NumSteps];
        }

        public string DisplayIngredients1()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string output1 = "\nIngredients";

            for (int i = 0; i < NumIngredients; i++)
            {
                output1 = $"{output1}\n" +
                $"{Math.Floor((oldIngredientQuan[i]) * 1) / 1} {oldUnits[i]} of {IngredientName[i]}";
            }

            return output1;
        }

        public void menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nPlease select from one of the following options:" +
                $"\n1) Display Ingredients" +
                $"\n2) Display Steps" +
                $"\n3) Scale ingredients" +
                $"\n4) Reset Quantities" +
                $"\n5) Clear the data" +
                $"\n6) Exit");
            int menuOption = Convert.ToInt16(Console.ReadLine());

            while ( menuOption == 0 || menuOption > 6)
            {
                Console.WriteLine($"Option not found please try again!\n" +
                $"Please select from one of the following options:\n" +
                $"1) Display Ingredients\n" +
                $"2) Display Steps\n" +
                $"3) Scale ingredients\n" +
                $"4) Reset Quantities\n" +
                $"5) Clear the data" +
                $"6) Exit");
            }

            while ( menuOption != 6)
            {
                switch (menuOption)
                {
                    case 1:
                        Console.WriteLine(DisplayIngredients2());
                        break;

                    case 2:
                        Console.WriteLine(DisplaySteps());
                        break;

                    case 3:
                        ScaleIngredients();
                        break;

                    case 4:
                        ResetQuantities();
                        break;

                    case 5:
                        ClearData();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

                Console.WriteLine($"Please select from one of the following options:\n" +
                $"1) Display Ingredients\n" +
                $"2) Display Steps\n" +
                $"3) Scale ingredients\n" +
                $"4) Reset Quantities\n" +
                $"5) Clear the data\n" +
                $"6) Exit");

                menuOption = Convert.ToInt16(Console.ReadLine());
            }
            
        }

        public void ScaleIngredients()
        {
            Console.WriteLine("Please select a ratio you would like to apply to your RECIPE:" +
               "\n1: Double Ratio" +
               "\n2: Triple Ratio" +
               "\n3: Half Ratio" +
               "\n4: Do not make any Changes!");
            int ratioChoice = Convert.ToInt32(Console.ReadLine());

            if (ratioChoice == 1)
            {
                
                for (int s = 0; s < NumIngredients; s++)

                {
                    newIngredientQuan[s] = Convert.ToDouble(oldIngredientQuan[s] * 2); //double the quantity
                    if ((oldUnits[s] == "Teaspoons" || oldUnits[s] == "Teaspoon") && newIngredientQuan[s] >= 3)
                    {
                        ScaleAmount = 3;
                        newIngredientQuan[s] = newIngredientQuan[s] / 3;
                        quantityRemainder[s] = Math.Floor((newIngredientQuan[s] % 3) * 1) / 1;

                        if (newIngredientQuan[s] > 1)
                        {
                            newUnits[s] = "Tablespoons";
                        }
                        else
                        {
                            newUnits[s] = "Tablespoon";
                        }
                    }

                    if ((oldUnits[s] == "Tablespoons" || oldUnits[s] == "Tablespoon") && newIngredientQuan[s] >= 16)
                    {
                        ScaleAmount = 16;
                        newIngredientQuan[s] = newIngredientQuan[s] / 16;
                        quantityRemainder[s] = Math.Floor((newIngredientQuan[s] % 16) * 1) / 1;
                        if (newIngredientQuan[s] > 1)
                        {
                            newUnits[s] = "Cups";
                        }
                        else
                        {
                            newUnits[s] = "cups";
                        }
                    }

                    if (oldUnits[s] == "ml" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "l";
                    }

                    if (oldUnits[s] == "mg" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "g";
                    }

                    if (oldUnits[s] == "g" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "kg";
                    }
                }
                Console.WriteLine("Ingredients scaled.");
            }
            else if(ratioChoice == 2)
            {
                for (int s = 0; s < NumIngredients; s++)

                {
                    newIngredientQuan[s] = Convert.ToDouble(oldIngredientQuan[s] * 3); //triple the quantity
                    if ((oldUnits[s] == "Teaspoons" || oldUnits[s] == "Teaspoon") && newIngredientQuan[s] >= 3)
                    {
                        ScaleAmount = 3;
                        newIngredientQuan[s] = newIngredientQuan[s] / 3;
                        quantityRemainder[s] = Math.Floor((newIngredientQuan[s] % 3) * 1) / 1;

                        if (newIngredientQuan[s] > 1)
                        {

                            newUnits[s] = "Tablespoons";
                        }
                        else
                        {
                            newUnits[s] = "Tablespoon";
                        }
                    }

                    if ((oldUnits[s] == "Tablespoons" || oldUnits[s] == "Tablespoon") && newIngredientQuan[s] >= 16)
                    {
                        ScaleAmount = 16;
                        newIngredientQuan[s] = newIngredientQuan[s] / 16;
                        quantityRemainder[s] = Math.Floor((newIngredientQuan[s] % 16) * 1) / 1;

                        if (newIngredientQuan[s] > 1)
                        {
                            newUnits[s] = "Cups";
                        }
                        else
                        {
                            newUnits[s] = "cups";
                        }
                    }

                    if (oldUnits[s] == "ml" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "l";
                    }

                    if (oldUnits[s] == "mg" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "g";
                    }

                    if (oldUnits[s] == "g" && newIngredientQuan[s] >= 1000)
                    {
                        newUnits[s] = "kg";
                    }
                }
                Console.WriteLine("Ingredients scaled.");
            }
            else if (ratioChoice == 3)
            {
                for (int s = 0; s < NumIngredients; s++)

                {
                    newIngredientQuan[s] = Convert.ToDouble(oldIngredientQuan[s]) / 2; //half the quantity
                    if ((oldUnits[s] == "Tablespoons" || oldUnits[s] == "Tablespoon") && newIngredientQuan[s] <= 1)
                    {
                        newIngredientQuan[s] = newIngredientQuan[s] * 3;

                        if (newIngredientQuan[s] < 1)
                        {
                            newUnits[s] = "Teaspoons";
                        }
                        else
                        {
                            newUnits[s] = "Teaspoon";
                        }
                    }

                    if ((oldUnits[s] == "Cups" || oldUnits[s] == "Cup") && newIngredientQuan[s] <= 1)
                    {
                        ScaleAmount = 3;
                        newIngredientQuan[s] = newIngredientQuan[s] * 16;
                        quantityRemainder[s] = Math.Floor((newIngredientQuan[s] % 3) * 1) / 1;
                        if (newIngredientQuan[s] < 1)
                        {
                            newUnits[s] = "Tablespoons";
                        }
                        else
                        {
                            newUnits[s] = "Tablespoon";
                        }
                    }

                    if (oldUnits[s] == "l" && newIngredientQuan[s] <= 1)
                    {
                        newUnits[s] = "ml";
                    }

                    if (oldUnits[s] == "g" && newIngredientQuan[s] <= 1)
                    {
                        newUnits[s] = "mg";
                    }

                    if (oldUnits[s] == "kg" && newIngredientQuan[s] <= 1)
                    {
                        newUnits[s] = "g";
                    }

                }
                Console.WriteLine("Ingredients scaled.");
            }
            else if( ratioChoice == 4)
            {
                Console.WriteLine($"Ingredient quantity unchanged");
            }
        }

        public void ResetQuantities()
        {
            for (int r = 0; r < NumIngredients; r++)
            {
                newIngredientQuan[r] = oldIngredientQuan[r];
                newUnits[r] = oldUnits[r];
            }
            Console.WriteLine("Ingredient quanities reset.");
        }

        public void ClearData()
        {
            NumIngredients = 0;
            NumSteps = 0;
            Array.Clear(IngredientName, 0, NumIngredients);
            Array.Clear(oldIngredientQuan, 0, NumIngredients);
            Array.Clear(newIngredientQuan, 0, NumIngredients);
            Array.Clear(oldUnits, 0, NumIngredients);
            Array.Clear(newUnits, 0, NumIngredients);
            //for (int c = 0; c < NumIngredients; c++)
            //{
                
            //    IngredientName[c] = "";
            //    oldIngredientQuan[c] = 0;
            //    newIngredientQuan[c] = 0;
            //    oldUnits[c] = "";
            //    newUnits[c] = "";
            //}
            Console.WriteLine("Data cleared.");

            Program.Main();
        }

        public string DisplayIngredients2()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string output1 = "\nIngredients";

            for (int i = 0; i < NumIngredients; i++)
            {
                output1 = $"{output1}\n" +
                $"{Math.Floor((newIngredientQuan[i]) * 1) / 1} {quantityRemainder[i]}/{ScaleAmount} {newUnits[i]} of {IngredientName[i]}";
            }

            return output1;
        }

        public string DisplaySteps()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string output2 = "\nSteps\n";

            for (int i = 0; i < NumSteps; i++)
            {
                output2 = $"{output2}" +
                    $"Step {i + 1}: {Steps[i]}";
            }

            return output2;
        }
    }

}
