using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cSharp_SimpleNoteApplication
{
    internal class Menu
    {
        //private static string NoteDirectory = "/Note";
        public void DisplayMenu()
        {
            Console.WriteLine("Menu: \n1) New note\n2) Edit note\n3) Read note\n4) Delete note\n5) Display notes\n6) Exit");
            while (true)
            {
                try
                {
                    Console.Write("\nPlease select an option: ");
                    string option = Console.ReadLine();
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    switch (NoOption)
                    {
                        case 1:
                            NewNote();
                            break;
                        case 2:
                            // EditNote();
                            break;
                        case 3:
                            //ReadNote();
                            break;
                        case 4:
                            //DeleteNote();
                            break;
                        case 5:
                            //DisplayNote();
                            break;
                        case 6:
                            Console.Write("Are you sure you want to exit? (y/n) "); // Check if the user want to exit the application
                            string ExitInput = Console.ReadLine();
                            ExitInput.ToLower();
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
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        static void NewNote()
        {
            Console.WriteLine("Please enter note title:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter note content:");
            string content = Console.ReadLine();
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"); //date and time
            // add to the list

            XmlWriterSettings NoteSettings = new XmlWriterSettings();

            NoteSettings.CheckCharacters = false;
            NoteSettings.ConformanceLevel = ConformanceLevel.Auto;
            NoteSettings.Indent = true;

            string FileName = title + ".xml";
            using (XmlWriter NewNote = XmlWriter.Create(FileName, NoteSettings))
            {

                NewNote.WriteStartDocument();
                NewNote.WriteStartElement("Title", title);
                NewNote.WriteElementString("dateTime", dateTime);
                NewNote.WriteElementString("Content", content);
                NewNote.WriteEndElement();

                NewNote.Flush();
                NewNote.Close();


            }
        }
    }
}
