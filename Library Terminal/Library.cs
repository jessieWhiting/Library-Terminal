using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library_Terminal
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public Book DavidCopperField = new Book("David Copper Field", "Charles Dickens", true);
        public Book THWOD = new Book("The Hilarious world of Depression", "John Moe", true);
        public Book GrumpyMonkey = new Book("Grumpy Monkey", "Suzanne Lang", true);
        public Book Eragon = new Book("Eragon", "Christopher Paolini", true);
        public Book FairyTale = new Book("Fairy Tale", "Stephen King", true);
        public Book TheHobbit = new Book("The Hobbit", "J.R.R Tolkein", false);
        public Book ThePostmortal = new Book("The Postmortal", "Drew Magary", true);
        public Book TheVagrant = new Book("The Vagrant", "Peter Newman", true);
        public Book DarkMatter = new Book("Dark Matter", "Blake Crouch", true);
        public Book TheGoldenCompass = new Book("The Golden Compass", "Phillip Pullman", false);
        public Book FireAndBlood = new Book("Fire & Blood", "George R.R Martin", true);
        public Book LiarsKey = new Book("Liars Key", " Mark Lawrence", false);

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
            Books.OrderBy(Book => Book.Title).ToList();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i}: {Books.OrderBy(Book => Book.Title).ToList()[i].Title}");
            }
        }


        public void HowShouldWeSearch()
        {
            while (true)
            {
                Console.WriteLine("Would you like to search by Author or Title?");
                Console.WriteLine("( Please note, we have inputed searching by keyword into our Library system! )");

                string userInput = Console.ReadLine().ToLower();

                if (userInput == "author")
                {
                    Console.WriteLine("Searching by author!");

                    break;
                }
                else if (userInput == "title")
                {
                    Console.WriteLine("Searching by Title");
                    List<string> keywords = new List<string>(SearchByKeyword());
                    PickFromList(keywords);
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
                if (book.Title.Contains(userInput))
                {
                    configuredKeywordList.Add(book.Title);
                }
            }
            return configuredKeywordList;
        }


        public string PickFromList(List<string> configuredList) 
        {
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
            Console.WriteLine($"You have chosen {configuredList[userAnswer - 1]} ");
            return configuredList[userAnswer - 1];
        }


    


    }
}
