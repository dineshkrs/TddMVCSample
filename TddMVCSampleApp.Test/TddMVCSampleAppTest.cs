using NUnit.Framework;
using System.Collections.Generic;
using TddMVCSampleApp.Controllers;
using TddMVCSampleApp.Models;
using TddMVCSampleApp.Test.Repositories;
using System.Web.Mvc;

namespace TddMVCSampleApp.Test
{
    [TestFixture]
    public class TddMVCSampleAppTest
    {
        Book book1 = null;
        Book book2 = null;
        Book book3 = null;
        Book book4 = null;
        Book book5 = null;

        List<Book> books = null;
        DummyBooksRepository _booksRepo = null;
        UnitOfWork uow = null;
        BooksController controller = null;

        public TddMVCSampleAppTest()
        {
            // Lets create some sample books

            book1 = new Book { ID = 4, BookName = "test1", AuthorName = "test1", ISBN = "NA" };
            book2 = new Book { ID = 5, BookName = "test2", AuthorName = "test2", ISBN = "NA" };
            book3 = new Book { ID = 6, BookName = "test3", AuthorName = "test3", ISBN = "NA" };
            book4 = new Book { ID = 7, BookName = "test4", AuthorName = "test4", ISBN = "NA" };
            book5 = new Book { ID = 3, BookName = "The Best Little Ghost", AuthorName = "Johnny Boo", ISBN = "978-1-891830-75-4" };

            books = new List<Book>
           {
               book1,
               book2,
               book3,
               book4
           };

            // Lets create our dummy repository
            _booksRepo = new DummyBooksRepository(books);
            // Let us now create the Unit of work with our dummy repository
            uow = new UnitOfWork(_booksRepo);

            // Now lets create the BooksController object to test and pass our unit of work
            controller = new BooksController(uow);
        }

        [Test]
        public void Index_Returns_AllRows()
        {

            // Lets call the action method now
            ViewResult result = controller.Index() as ViewResult;

            // Now lets evrify whether the result contains our book entries or not
            var model = (List<Book>)result.ViewData.Model;

            CollectionAssert.Contains(model, book1);
            CollectionAssert.Contains(model, book2);
            CollectionAssert.Contains(model, book3);
            CollectionAssert.Contains(model, book4);

            // Uncomment the below line and the test will start failing
            CollectionAssert.Contains(model, book5);
        }
        [Test]
        public void Details()
        {
            ViewResult result = controller.Details(4) as ViewResult;

            Assert.AreEqual(result.Model, book1);
        }
        [Test]
        public void Create()
        {
            // Lets create a new book object
            Book newBook = new Book { ID = 7, BookName = "new", AuthorName = "new", ISBN = "NA" };

            //Add the book object in the book object;
            controller.Create(newBook);

            List<Book> bookList = _booksRepo.GetAllBooks();
            CollectionAssert.Contains(bookList, newBook);
        }
        [Test]
        public void Edit()
        {
            // Lets create a valid book objct to add into
            Book editedBook = new Book { ID = 4, BookName = "test1", AuthorName = "test1", ISBN = "NA" };

            //Lets create a edit using controller
            controller.Edit(editedBook);

            List<Book> bookList = _booksRepo.GetAllBooks();
            CollectionAssert.Contains(bookList, editedBook);
        }

        [Test]
        public void Delete()
        {
            // Delte record from the table 
            controller.Delete(4);

            List<Book> bookList = _booksRepo.GetAllBooks();

            CollectionAssert.Contains(bookList, book1);

        }
    }
}
