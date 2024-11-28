namespace Inlamningsuppgift2komplettering;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Fördefinierade böcker
    private static List<Book> books = new List<Book>
    {
        new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", IsCheckedOut = false },
        new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935", IsCheckedOut = false },
        new Book { Title = "Moby Dick", Author = "Herman Melville", ISBN = "9781503280786", IsCheckedOut = false },
        new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9781503290563", IsCheckedOut = false },
        new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", IsCheckedOut = false }
    };

    public static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Search for a Book by Author");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Check Out / Return a Book");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    SearchByAuthor();
                    break;
                case "4":
                    ViewAllBooks();
                    break;
                case "5":
                    ToggleCheckOut();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter book author: ");
        string author = Console.ReadLine();

        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        books.Add(new Book { Title = title, Author = author, ISBN = isbn, IsCheckedOut = false });
        Console.WriteLine("Book added successfully.");
    }

    private static void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();
        var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    private static void SearchByAuthor()
    {
        Console.Write("Enter author name: ");
        string author = Console.ReadLine();
        var results = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Any())
        {
            Console.WriteLine("Books by the author:");
            results.ForEach(b => Console.WriteLine(b));
        }
        else
        {
            Console.WriteLine("No books found by that author.");
        }
    }

    private static void ViewAllBooks()
    {
        if (books.Any())
        {
            Console.WriteLine("Books in the library:");
            books.ForEach(b => Console.WriteLine(b));
        }
        else
        {
            Console.WriteLine("No books in the library.");
        }
    }

    private static void ToggleCheckOut()
    {
        Console.Write("Enter the title of the book to check out/return: ");
        string title = Console.ReadLine();
        var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            book.IsCheckedOut = !book.IsCheckedOut;
            Console.WriteLine($"Book '{book.Title}' is now {(book.IsCheckedOut ? "Checked Out" : "Returned")}.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}
