using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
namespace cSharp_SimpleNoteApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("      Welcome To    ");
            Console.WriteLine(" +-+-+-+-+-+-+-+-+-+\r\n |W|h|a|t|I|s|F|u|n|\r\n +-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("        Notes      \n");
            Menu menu = new Menu();
            menu.DisplayMenu();

        }
    }
}