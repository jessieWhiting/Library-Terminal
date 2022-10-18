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

            Library lib = new Library();
            /////////////////////////////////////////////////////////////////////////////
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                
                lib.HowShouldWeSearch();
                if (ContinueLoop("Rent another book? Y/N") == false)
                {
                    break;
                }
            }

            //Date and time here:
            lib.ReturnDate();
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Thanks for keeping libraries alive. You book is due two weeks from now. Now Shh.");
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Press any key to save data.");

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