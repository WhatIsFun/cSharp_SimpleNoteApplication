using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_SimpleNoteApplication
{
    internal class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Menu: \n1) New note\n2) Edit note\n3) Read note\n4) Delete note\n5) Display notes\n6) Exit");
            while (true)
            {
                Console.Write("\nPlease select an option: ");
                string option = Console.ReadLine();
                try
                {
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    if (NoOption < 0 || NoOption > 7) { Console.WriteLine("Invalid input. Please enter a number between 1 and 6."); }
                    switch (NoOption)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                        case 6:
                            Console.Write("Are you sure you want to exit? (y/n)"); // Check if the user want to exit the application
                            string ExitInput = Console.ReadLine();
                            if (ExitInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Thank You");
                                Environment.Exit(0);
                            }
                            else
                            {
                                DisplayMenu();
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
