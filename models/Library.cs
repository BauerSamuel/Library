using System.Collections.Generic;
using System;
namespace practice.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }
    private List<Book> CheckedOut { get; set; }
    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
      return;
    }
    public void PrintBooks()
    {
      Console.WriteLine($"Welcome to the {Name}, we have {Books.Count} book(s) for you to check out. Here's what we have in stock:\n");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
      }
    }
    public void Checkout(string selection)
    {
      Book rentedBook = ValidateBook(selection, Books);
      if (rentedBook == null)
      {
        Console.Clear();
        Console.WriteLine("Invalid selection\n");
        return;
      }
      rentedBook.Available = false;
      CheckedOut.Add(rentedBook);
      Books.Remove(rentedBook);
      Console.WriteLine($"Thank you for shopping with us, here is your new book: {rentedBook.Title}");
      return;
    }
    public void Return(string selection)
    {
      Book returnedBook = ValidateBook(selection, CheckedOut);
      if (returnedBook == null)
      {
        Console.Clear();
        Console.WriteLine("That one's not one of ours...\n");
        return;
      }
      returnedBook.Available = true;
      CheckedOut.Remove(returnedBook);
      Books.Add(returnedBook);
      Console.WriteLine($"Thanks for returning back the book.");
      return;
    }

    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = -1;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 0 || bookIndex > bookList.Count)
      {
        return null;
      }
      return bookList[bookIndex - 1];
    }

    public void PrintCheckedOutBooks()
    {
      Console.WriteLine($"Books checked out:\n");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
      }
    }
  }
}