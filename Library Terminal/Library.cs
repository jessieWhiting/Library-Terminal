using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Terminal
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        
        //public Book DavidCopperField = new Book("David Copper Field", "Charles Dickens", "Available");
        //public Book THWOD = new Book("The Hilarious world of Depression", "John Moe", "Is Checked Out");
        //public Book GrumpyMonkey = new Book("Grumpy Monkey", "Suzanne Lang", "Available");
        //public Book Eragon = new Book("Eragon", "Christopher Paolini", "Available");
        //public Book FairyTale = new Book("Fairy Tale", "Stephen King", "Available");
        //public Book TheHobbit = new Book("The Hobbit", "J.R.R Tolkein", "Available");
        //public Book ThePostmortal = new Book("The Postmortal", "Drew Magary", "Available");
        //public Book TheVagrant = new Book("The Vagrant", "Peter Newman", "Available");
        //public Book DarkMatter = new Book("Dark Matter", "Blake Crouch", "Available");
        //public Book TheGoldenCompass = new Book("The Golden Compass", "Phillip Pullman", "Is Checked Out");
        //public Book FireAndBlood = new Book("Fire & Blood", "George R.R Martin", "Available");
        //public Book LiarsKey = new Book("Liars Key", " Mark Lawrence", "Is Checked Out");
        //public Book EncyclopediaBrown = new Book("Encyclopedia Brown", "Donald Sobol", "Available");
        //public Book TBIAF = new Book("This Book Is Fake", "Jessie Whiting", "Available");
        //public Book IFT = new Book("Still a Fake", "Brandon Leatherman", "Available");
        //public Book FakeyFakey = new Book("Fakey Fakey", "Liam Donelson", "Is Checked Out");
        //public Book MysteriousBook = new Book("A Mysterious Book Appears", "Liam Donelson", "Available");
        //public Book OhLookABook = new Book("Oh Look a Book", " Brandon Leatherman", "Is Checked Out");
        //public Book CanIEatThis = new Book("Can I eat this? ", "Jessie Whiting", "Is Checked Out");

        public Library()
        {
            Books = ReadFile();
            //Books.Add(DavidCopperField);
            //Books.Add(THWOD);
            //Books.Add(GrumpyMonkey);
            //Books.Add(Eragon);
            //Books.Add(FairyTale);
            //Books.Add(TheHobbit);
            //Books.Add(ThePostmortal);
            //Books.Add(TheVagrant);
            //Books.Add(DarkMatter);
            //Books.Add(FireAndBlood);
            //Books.Add(LiarsKey);
            //Books.Add(EncyclopediaBrown);
            //Books.Add(TBIAF);
            //Books.Add(IFT);
            //Books.Add(FakeyFakey);
            //Books.Add(MysteriousBook);
            //Books.Add(OhLookABook);
            //Books.Add(CanIEatThis);
        }

        public void PrintBooks()
        {
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Library: ");
            Console.WriteLine("=================================================================================");
            Books.OrderBy(Book => Book.Title).ToList();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Books.OrderBy(Book => Book.Title).ToList()[i].Title}");

            }
            Console.WriteLine("=================================================================================");

        }


        public Book Checkout()
        {
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("Select a Book: ");
            Console.WriteLine("==================================================================================================================");
            PrintBooks();
            bool outbook = true;
            Book b;
            while (outbook)
            {
                try
                {
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput > 0 && userInput < Books.Count + 1)
                    {

                        b = Books.OrderBy(Book => Book.Title).ToList()[userInput - 1];

                        if (b.IsCheckedOut.Contains("Available"))
                        {

                            Console.WriteLine("==================================================================================================================");
                            Console.WriteLine($"Checking out " + b.Title);
                            Console.WriteLine("==================================================================================================================");
                            return b;

                        }
                        else
                        {

                            Console.WriteLine($"This book has already been checked out. 1 to {Books.Count}");

                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"That is not a valid book to checkout. 1 to {Books.Count}");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please choose a valid book selection. 1 to {Books.Count}");
                    continue;
                }
            }
            return Checkout();
        }
        public List<string> SearchByAuthor()
        {
            List<string> bookListByAuthor = new List<string>();

            Console.WriteLine("What Author would you like to select?");

            string authorSelection = Console.ReadLine();
            string author = UpperCaseWord(authorSelection);

            foreach (Book book in Books)
            {

                if (book.Author.Contains(author) && book.IsCheckedOut.Contains("Available"))
                {
                    bookListByAuthor.Add(book.Title);
                }

            }
            if (bookListByAuthor.Count == 0)
            {
                Console.WriteLine("Sorry, we do not have a book by that Author");
                SearchByAuthor();
            }

            return bookListByAuthor;
        }
        public List<string> ReturnBook()
        {
            Console.WriteLine("Select a book to return.");
            List<string> bookToReturn = new List<string>();

            foreach (Book book in Books)
            {
                if (book.IsCheckedOut == "Is Checked Out")
                {
                    bookToReturn.Add(book.Title);
                }
            }
            return bookToReturn;
        }


        public string UpperCaseWord(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string upperCaseSentence = textInfo.ToTitleCase(input);
            return upperCaseSentence;
        }

        public void HowShouldWeSearch()
        {
            while (true)
            {
                Console.WriteLine("=================================================================================");
                Console.WriteLine("Welcome to: The Library of Misfit Books: \n");
                Console.WriteLine("=================================================================================");
                Console.WriteLine("(Please note, we have inputed searching by keyword into our Library system!)");
                Console.WriteLine("Enter |N| to view collection:\nEnter |Return| to return a book. \nType |Author| or |Title| for key searching.");


                string userInput = Console.ReadLine().ToLower();

                if (userInput == "author" || userInput == "A")
                {
                    Console.WriteLine("Searching by author!");
                    List<string> authors = new List<string>(SearchByAuthor());
                    PickFromList(authors);
                    break;
                }
                else if (userInput == "title" || userInput == "t")
                {
                    Console.WriteLine("Searching by Title");
                    List<string> keywords = new List<string>(SearchByKeyword());
                    PickFromList(keywords);
                    break;
                }
                else if (userInput == "return" || userInput == "r" )
                {
                    Console.WriteLine("Returning book");
                    List<string> checkedOut = new List<string>(ReturnBook());
                    PickFromList(checkedOut);
                    break;

                }
                else if (userInput == "n")
                {
                    Checkout();
                    break;
                }
                else
                {
                    Console.WriteLine("Hmmm, I'm not sure what you mean by that. Could you try it again?");
                    Console.WriteLine($"Enter |N| to view collection:\nEnter |Return| to return a book.\nType |Author| or |Title| for key searching.");
                    continue;
                }

            }
        }

        public void ReturnDate()
        {
            DateTime today = DateTime.Today;
            today = today.AddDays(12);
            Console.WriteLine("This book is due back : " + today.ToString("d"));
        }

        public List<string> SearchByKeyword()
        {
            Console.WriteLine("Please input a title or keyword that you would like to search for");
            string input = Console.ReadLine();
            string userInput = UpperCaseWord(input);

            List<string> configuredKeywordList = new List<string>();

            foreach (Book book in Books)
            {
                if (book.Title.Contains(userInput) && book.IsCheckedOut.Contains("Available"))
                {
                    configuredKeywordList.Add(book.Title);
                }
            }

            for (int i = 0; i < configuredKeywordList.Count; i++)
            {
                Book b = Books.Where(x => x.IsCheckedOut == "Available").First();

            }

            return configuredKeywordList;
        }


        public string PickFromList(List<string> configuredList)
        {

            int x = 0;
            Console.WriteLine($"Please select a number from the list below!");
            Console.WriteLine("====================================================");
            foreach (string keyword in configuredList)
            {
                x++;
                Console.WriteLine($"{x}:{keyword}");
            }
            int userAnswer = 0;
            while (true)
            {

                try
                {
                    userAnswer = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine($"Please input the valid number of the book you would like to checkout! 1 - {x}");
                    continue;
                }
            }

                if (configuredList.Contains("Available"))
                {
                  Console.WriteLine("");
                  Console.WriteLine($"You have checked out {configuredList[userAnswer - 1]}!");
                    
                }
            else
            {
                Console.WriteLine($"Returned: {configuredList[userAnswer -1]}.");
            }

            return configuredList[userAnswer - 1];

        }

        public List<Book> ReadFile()
        {

            string filePath = @"..\..\..\books.txt";
            StreamReader reader = new StreamReader(filePath);
            string textDump = reader.ReadToEnd();

            string[] books = textDump.Split("\n");

            List<Book> myLib = new List<Book>();
            foreach (string book in books)
            {
                string[] bookProps = book.Split(",");
                myLib.Add(new Book(bookProps[0], bookProps[1], bookProps[2]));
            }
            reader.Close();
            return myLib;
        }


        public void WriteFile() {

            string filePath = @"..\..\..\books.txt";
            StreamWriter streamWriter = new StreamWriter(filePath);
            string outputToFile = "";
            foreach(Book book in Books)
            {
                string masterstring = $"{book.Title},{book.Author},{book.IsCheckedOut}\n";
                outputToFile += masterstring;
            }
            outputToFile = outputToFile.Substring(0, outputToFile.Length-1);
            //Write overrides the content of the file with the input string, 
            //It does NOT add to the file.
            streamWriter.Write(outputToFile);
            streamWriter.Close();

        }










    }
}


