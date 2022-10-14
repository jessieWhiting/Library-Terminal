using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            Books.OrderBy(Book => Book.Title).ToList();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Books.OrderBy(Book => Book.Title).ToList()[i].Title}");
              
            }

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
                catch(Exception)
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
                if (books.Author.Contains(author))
                {
                    bookListByAuthor.Add(books.Title);
                }
                else
                {
                    Console.WriteLine("Sorry, we do not have a book by that Author");
                    break;
                }
            }
            return bookListByAuthor;
            
        }
        public void ReturnBook()
        {
            Console.WriteLine("What book would you like to return?");
            string input = Console.ReadLine();

            foreach(Book book in Books)
            {
                if (book.Title.Contains(input))
                {
                    Console.WriteLine("Thank you");
                }
                else
                {
                    Console.WriteLine("Sorry, That is not one of our books");
                    break;
                }


            }
          

        }  
    }
}


