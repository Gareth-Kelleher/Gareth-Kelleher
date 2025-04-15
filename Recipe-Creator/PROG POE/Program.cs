using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG_POE
{
    internal class Program
    {

        public static void Main(/*string[] args*/)
        {
            //double dec = 4 / 3;
            //double rem = dec % 3;
            //var output = Math.Floor((dec) * 1) / 1;
            //Console.WriteLine($"{output} {rem}/3    {dec}");

            //Console.Read();

            //declare number of ingredients and steps
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.Write("Enter the number of ingredients in your recipe: ");
            int ingredientAmount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of steps: ");
            int stepAmount = Convert.ToInt32(Console.ReadLine());

            POE_Part1 poe1 = new POE_Part1(ingredientAmount, stepAmount);

            //populate ingredient details
            
            for (int i = 0; i < ingredientAmount; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"\nEnter the name of ingredient {i + 1}: ");
                poe1.IngredientName[i] = Console.ReadLine();
                Console.Write($"Enter the quantity of ingredient {i + 1}: ");
                poe1.oldIngredientQuan[i] = Convert.ToInt16(Console.ReadLine());
                poe1.newIngredientQuan[i] = poe1.oldIngredientQuan[i];
                Console.WriteLine($"Select the unit of measurement for ingredient {i + 1}: " +
                    $"\n1) Cups" +
                    $"\n2) Tablespoons" +
                    $"\n3) Teaspoons" +
                    $"\n4) ml" +
                    $"\n5) l" +
                    $"\n6) mg" +
                    $"\n7) g" +
                    $"\n8) kg");
                int unitOption = Convert.ToInt16(Console.ReadLine());
                switch (unitOption)
                {
                    case 1:
                        if (poe1.oldIngredientQuan[i] == 1)
                        {
                            poe1.oldUnits[i] = "Cup";
                        }
                        else
                        {
                            poe1.oldUnits[i] = "Cups";
                        }
                    break;

                    case 2:
                        if (poe1.oldIngredientQuan[i] == 1)
                        {
                            poe1.oldUnits[i] = "Tablespoon";
                        }
                        else
                        {
                            poe1.oldUnits[i] = "Tablespoons";
                        }
                    break;

                    case 3:
                        if (poe1.oldIngredientQuan[i] == 1)
                        {
                            poe1.oldUnits[i] = "Teaspoon";
                        }
                        else
                        {
                            poe1.oldUnits[i] = "Teaspoons";
                        }
                    break;

                    case 4:
                        poe1.oldUnits[i] = "ml";
                    break;

                    case 5:
                        poe1.oldUnits[i] = "l";
                    break;

                    case 6:
                        poe1.oldUnits[i] = "mg";
                    break;

                    case 7:
                        poe1.oldUnits[i] = "g";
                    break;

                    case 8:
                        poe1.oldUnits[i] = "kg";
                    break;

                    default:
                        break;
                }
                poe1.newUnits[i] = poe1.oldUnits[i];
            }

            for (int i = 0; i < stepAmount; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.Write($"\nDescribe step {i + 1}: ");
                poe1.Steps[i] = Console.ReadLine();
            }

            //Display ingredients and steps
            Console.WriteLine(poe1.DisplayIngredients1());
            Console.WriteLine(poe1.DisplaySteps());

            //Menu
            poe1.menu();
        }
    }
}
