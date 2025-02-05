using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    

public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; } = false;

        public void Borrow() => IsBorrowed = true; // Marks the book as borrowed
        public void Return() => IsBorrowed = false; // Marks the book as available
    }

    // Represents a borrower
    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; } = new List<Book>(); // Stores borrowed books

        public void BorrowBook(Book book)
        {
            if (!book.IsBorrowed) // Check if book is available
            {
                book.Borrow();
                BorrowedBooks.Add(book); // Add book to borrower's list
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Remove(book)) // Remove book from borrower's list
                book.Return();
        }
    }

    // Represents the library
    public class Library
    {
        private List<Book> Books { get; } = new List<Book>(); // Stores all books
        private List<Borrower> Borrowers { get; } = new List<Borrower>(); // Stores all borrowers

        public int AddBook(Book book) { Books.Add(book); return Books.Count(); } // Adds a new book to the library
        public int RegisterBorrower(Borrower borrower) {
            Borrowers.Add(borrower);
            return Borrowers.Count();
        } // Registers a new borrower

        public bool BorrowBook(string isbn, string cardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == cardNumber);
            if (book != null && borrower != null)
            {
                borrower.BorrowBook(book);
                return true; // Successfully borrowed
            }
            return false; // Borrowing failed
        }

        public bool ReturnBook(string isbn, string cardNumber)
        {
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == cardNumber);
            var book = borrower.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                borrower.ReturnBook(book);
                return true; // Successfully returned
            }
            return false; // Returning failed
        }

        public void ViewBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("List of Books:");
            foreach (var book in Books)
            {
                string status = book.IsBorrowed ? "Borrowed" : "Available";
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Status: {status}");
            }
        }

        public void ViewBorrowers()
        {
            if (Borrowers.Count == 0)
            {
                Console.WriteLine("No borrowers registered.");
                return;
            }

            Console.WriteLine("List of Borrowers:");
            foreach (var borrower in Borrowers)
            {
                Console.WriteLine($"Name: {borrower.Name}, Card Number: {borrower.LibraryCardNumber}, Books Borrowed: {borrower.BorrowedBooks.Count}");
            }
        }

    }


} 




