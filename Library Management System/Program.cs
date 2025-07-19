namespace Library_Management_System
{using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    // Attributes
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Availability { get; set; }

    // Constructor
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Availability = true; // Initially available for borrowing
    }
}

public class Library
{
    // Collection of books
    private List<Book> books;

    // Constructor
    public Library()
    {
        books = new List<Book>();
    }

    // Methods

    // Add a new book to the library collection
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    // Search for a book by Title or Author
    public Book SearchBook(string searchTerm)
    {
        return books.FirstOrDefault(b => b.Title.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                          b.Author.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
    }

    // Borrow a book
    public void BorrowBook(string searchTerm)
    {
        Book book = SearchBook(searchTerm);
        if (book != null)
        {
            if (book.Availability)
            {
                book.Availability = false; // Mark as unavailable
                Console.WriteLine($"You have borrowed '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"Sorry, '{book.Title}' is currently not available.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Return a book
    public void ReturnBook(string searchTerm)
    {
        Book book = SearchBook(searchTerm);
        if (book != null)
        {
            book.Availability = true; // Mark as available
            Console.WriteLine($"You have returned '{book.Title}'.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Adding some books to the library
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
        library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));

        // Borrowing a book
        library.BorrowBook("1984");

        // Trying to borrow the same book again
        library.BorrowBook("1984");

        // Returning the book
        library.ReturnBook("1984");

        // Searching for a book
        var book = library.SearchBook("The Great Gatsby");
        if (book != null)
        {
            Console.WriteLine($"Found: {book.Title} by {book.Author}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}
   // internal class Program
        //static void Main(string[] args)
        {
           // Console.WriteLine("Hello, World!");
        }
