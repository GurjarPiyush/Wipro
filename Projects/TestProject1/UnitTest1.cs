using LibraryManagementSystem;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        Library library =new Library();

        [Test]
        public void TestAddBook()
        {
            var book = new Book { Title = "Test Book", Author = "Author", ISBN = "123" };
            int c=library.AddBook(book);
            Assert.That(c, Is.EqualTo(1));
        }

       
        

      [Test]
        public void TestBorrowBookandRegisterBorrower()
        {
            var book = new Book { Title = "Test Book", Author = "Author", ISBN = "123" };
            var borrower = new Borrower { Name = "John", LibraryCardNumber = "456" };
            int f = 0;
            f = library.RegisterBorrower(borrower);
            
            library.AddBook(book);
            
            bool h = library.BorrowBook("123", "456");

            Assert.That(f, Is.EqualTo(1));
            Assert.IsTrue(h);
        }

        [Test]
        public void TestReturnBook()
        {
            var book = new Book { Title = "Test Book", Author = "Author", ISBN = "123" };
            var borrower = new Borrower { Name = "John", LibraryCardNumber = "456" };
            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("123", "456");

            Assert.IsTrue(library.ReturnBook("123", "456"));
            Assert.IsFalse(book.IsBorrowed);
        }
    }
}