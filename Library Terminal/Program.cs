﻿using System.Security.Cryptography.X509Certificates;

namespace Library_Terminal
{
     public class Program
    {
        static void Main()
        {
            Library lib = new Library();
            /////////////////////////////////////////////////////////////////////////////
           
            bool CheckOutAnother = true;
            Console.WriteLine("Library: ");

            while (CheckOutAnother)
            {
                 Book checkOut = lib.Checkout();
                 lib.PrintBooks();

                Console.WriteLine("=================================================================================");
                CheckOutAnother = ContinueLoop("Rent another book?");
                Console.WriteLine("=================================================================================");
            }
            //Date and time here:
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Thanks for keeping libraries alive. You book is due two weeks from now. Now Shh.");
            Console.WriteLine("=================================================================================");
        }

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
        //Methof for getting user input
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine();
            return output;
        }
    }
}