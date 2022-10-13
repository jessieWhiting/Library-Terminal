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

        
    }

   
}
