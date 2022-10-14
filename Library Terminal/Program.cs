using System.Security.Cryptography.X509Certificates;

namespace Library_Terminal
{
     public class Program
    {
        static void Main()
        {
            
         Library lib = new Library();

            lib.SearchByAuthor();
            lib.ReturnBook();
        
        }
    }
}