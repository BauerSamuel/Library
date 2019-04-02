using System;
using System.Collections.Generic;
using practice.Models;

namespace practice
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      Book myBook = new Book("Captain Underpants", "Dave Pilkey");
      Book myOtherBook = new Book("Title1", "Author");
      Book myNewBook = new Book("Title", "Author1");
      Library myLibrary = new Library("Broadway", "Boise Public Library");
      bool shopping = true;
      myLibrary.AddBook(myBook);
      myLibrary.AddBook(myOtherBook);
      myLibrary.AddBook(myNewBook);
      while (shopping)
      {
        myLibrary.PrintBooks();

        Console.WriteLine("\nSelect a book number to checkout, (q)uit, or (r)eturn a book");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "r")
        {
          myLibrary.PrintCheckedOutBooks();
          Console.WriteLine("Select a book number to return that book: ");
          answer = Console.ReadLine();
          myLibrary.Return(answer);
        }
        else if (answer.ToLower() == "q")
        {
          Console.WriteLine("Thaks for coming in. Have a good one.");
          shopping = false;
          return;
        }
        else
        {
          myLibrary.Checkout(answer);
        }
      }
    }
  }
}
