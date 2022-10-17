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
        public string IsCheckedOut { get; set; }  


        public Book(string Title, string Author, string IsCheckedOut)
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
