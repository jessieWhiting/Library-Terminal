using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Terminal
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; } = false;


        public Book(string Title, string Author, bool IsCheckedOut)
        {
            this.Title = Title;
            this.Author = Author;
            this.IsCheckedOut = IsCheckedOut;
        }

        



    }
    public enum Reads
    {
        //Not sure yet, Thinking titles.
    }
}
