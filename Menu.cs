using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace cSharp_SimpleNoteApplication
{
    internal class Menu
    {
        static List<Note> note = new List<Note>();
        private static string NoteDirectory = "Note App";
        private static string NoteFile = "Note App/Notes.xml";
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
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Please enter note title:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter note content:");
            string content = Console.ReadLine();
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"); //date and time
            // add to the list
            note.Add(new Note { Title = title, Content = content, DateTime = dateTime });
            Trace.WriteLine("Exiting Main");
            SaveNote();
        }
        static void SaveNote()
        {
            Trace.WriteLine("Entering SaveNote");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                using (TextWriter writer = new StreamWriter(NoteFile))
                {
                    serializer.Serialize(writer, note);
                }
                Console.WriteLine("Notes saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving notes: {ex.Message}");
            }
            Trace.WriteLine("Entering SaveNote");

        }
        public void LoadNote()
        {
            // Create Folder if it doesn't exist
            Directory.CreateDirectory(NoteDirectory);
            if (!File.Exists(NoteFile))
            {
                // Create an empty XML file if it doesn't exist
                File.WriteAllText(NoteFile, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ArrayOfNote xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></ArrayOfNote>");
                Console.WriteLine("XML file created.");
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                using (FileStream stream = File.OpenRead(NoteFile))
                {
                    note = (List<Note>)serializer.Deserialize(stream);
                }
                Console.WriteLine("Notes loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading notes: {ex.Message}");
            }
        }
    }
}
