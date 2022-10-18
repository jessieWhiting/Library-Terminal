using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;
using static System.Reflection.Metadata.BlobBuilder;
using System.IO;

namespace Library_Terminal
{
    public class Program
    {
        static void Main()
        {
            Console.ResetColor();
            Library lib = new Library();
            /////////////////////////////////////////////////////////////////////////////
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                lib.HowShouldWeSearch();
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Green;    
                if (ContinueLoop("Would you like to return to the menu? Y/N ") == false)
                {
                    break;
                } 
                Console.ResetColor();
            }
            
            //Date and time here:
            Console.ForegroundColor = ConsoleColor.Red;
            lib.ReturnDate();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================================================================");
            Console.WriteLine($"Thanks for keeping libraries alive. Your book is due two weeks from now. Now Shh.");
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Press any key to save data.");
            Console.ResetColor();
            lib.WriteFile();

        }
        //Method to continue
        public static bool ContinueLoop(string question)
        {
            string response = GetInput(question);
            if (response.ToUpper() == "Y")
            {
                return true;
            }
            else if (response.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Enter \"Y\" or \"N\".\n");
                return ContinueLoop(question);
            }
        }
        //Method for getting user input
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine();


            return output;
        }



    }
}