using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Terminal
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public Book DavidCopperField = new Book("David Copper Field", "Charles Dickens", "Available");
        public Book THWOD = new Book("The Hilarious world of Depression", "John Moe", "Is Checked out");
        public Book GrumpyMonkey = new Book("Grumpy Monkey", "Suzanne Lang", "Available");
        public Book Eragon = new Book("Eragon", "Christopher Paolini", "Available");
        public Book FairyTale = new Book("Fairy Tale", "Stephen King", "Available");
        public Book TheHobbit = new Book("The Hobbit", "J.R.R Tolkein", "Is Checked out");
        public Book ThePostmortal = new Book("The Postmortal", "Drew Magary", "Available");
        public Book TheVagrant = new Book("The Vagrant", "Peter Newman", "Available");
        public Book DarkMatter = new Book("Dark Matter", "Blake Crouch", "Available");
        public Book TheGoldenCompass = new Book("The Golden Compass", "Phillip Pullman", "Is Checked out");
        public Book FireAndBlood = new Book("Fire & Blood", "George R.R Martin", "Available");
        public Book LiarsKey = new Book("Liars Key", " Mark Lawrence", "Is Checked out");

        public Library()
        {
            Books.Add(DavidCopperField);
            Books.Add(THWOD);
            Books.Add(GrumpyMonkey);
            Books.Add(Eragon);
            Books.Add(FairyTale);
            Books.Add(TheHobbit);
            Books.Add(ThePostmortal);
            Books.Add(TheVagrant);
            Books.Add(DarkMatter);
            Books.Add(FireAndBlood);
            Books.Add(LiarsKey);
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
                            Console.WriteLine("This book has already been checked out.");
                            Checkout();
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
            string author = Console.ReadLine();

            foreach (Book books in Books)
            {
                if (books.Author.Contains(author) && books.IsCheckedOut.Contains("Available"))
                {
                    bookListByAuthor.Add(books.Title);
                }

            }
            if (bookListByAuthor.Count == 0)
            {
                Console.WriteLine("Sorry, we do not have a book by that Author");
            }
            return bookListByAuthor;

        }
        public void ReturnBook()
        {
            Console.WriteLine("What book would you like to return?");
            string input = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.Title.Contains(input) && book.IsCheckedOut.Contains("Available"))
                {
                    Console.WriteLine("Sorry, That is not one of our books");
                    break;
                }
                else
                {
                    Console.WriteLine("Thank you");
                    break;
                }


            }


        }


        public void HowShouldWeSearch()
        {
            while (true)
            {
                Console.WriteLine("Would you like to search by Author or Title? Or use the letter N to continue");
                Console.WriteLine("( Please note, we have inputed searching by keyword into our Library system! )");

                string userInput = Console.ReadLine().ToLower();

                if (userInput == "author")
                {
                    Console.WriteLine("Searching by author!");
                    List<string> authors = new List<string>(SearchByAuthor());
                    PickFromList(authors);
                    break;
                }
                else if (userInput == "title")
                {
                    Console.WriteLine("Searching by Title");
                    List<string> keywords = new List<string>(SearchByKeyword());
                    PickFromList(keywords);
                    break;
                }
                else if (userInput == "n")
                {
                    PrintBooks();
                    break;


                }
                else
                {
                    Console.WriteLine("Hmmm, I'm not sure what you mean by that. Could you try it again?");
                    Console.WriteLine($"Remember please answer with either Author or Title");
                    continue;
                }

            }
        }



        public List<string> SearchByKeyword()
        {
            Console.WriteLine("Please input a title or keyword that you would like to search for");
            string userInput = Console.ReadLine();
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
            for (int i = 0; i < configuredList.Count; i++)
            {




            }



            //foreach(Book book in Books)
            //{
            //    if()

            //    Console.WriteLine(book.IsCheckedOut);


            //}


            int x = 0;
            Console.WriteLine($"Please pick a number from the list below!");
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
            Console.WriteLine("");
            Console.WriteLine($"You have checked out {configuredList[userAnswer - 1]}!");
            return configuredList[userAnswer - 1];
        }

    }
}


