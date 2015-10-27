using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitTestingMVC;
using UnitTestingMVC.Controllers;
using UnitTestingMVC.Models;

namespace TestProject
{

    [TestClass]
    public class BooksControllerTest
    {
        Book book1 = null;
        Book book2 = null;
        Book book3 = null;
        Book book4 = null;
        Book book5 = null;

        List<Book> books = null;
        DummyBooksRepository booksRepo = null;
        UnitOfWork uow = null;
        HomeController controller = null;


        public BooksControllerTest()
        {
            // Lets create some sample books
            book1 = new Book { ID = 1, Book1 = "test1", AuthorName = "test1", ISBN = "NA" };
            book2 = new Book { ID = 2, Book1 = "test2", AuthorName = "test2", ISBN = "NA" };
            book3 = new Book { ID = 3, Book1 = "test3", AuthorName = "test3", ISBN = "NA" };
            book4 = new Book { ID = 4, Book1 = "test4", AuthorName = "test4", ISBN = "NA" };
            book5 = new Book { ID = 5, Book1 = "test5", AuthorName = "test5", ISBN = "NA" };

            books = new List<Book>
        {
            book1,
            book2,
            book3,
            book4
        };


            // Lets create our dummy repository
            booksRepo = new DummyBooksRepository(books);

            // Let us now create the Unit of work with our dummy repository
            uow = new UnitOfWork(booksRepo);

            // Now lets create the BooksController object to test and pass our unit of work
            controller = new HomeController(uow);
        }

        [TestMethod]
        public void Index()
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
            // CollectionAssert.Contains(model, book5);
        }

        [TestMethod]
        public void Details()
        {
            // Lets call the action method now

            ViewResult result = controller.Details(1) as ViewResult;

            // Now lets evrify whether the result contains our book
            Assert.AreEqual(result.Model, book1);
        }

        [TestMethod]
        public void Create()
        {
            // Lets create a valid book objct to add into
            Book newBook = new Book { ID = 7, Book1 = "new", AuthorName = "new", ISBN = "NA" };

            // Lets call the action method now
            controller.Create(newBook);

            // get the list of books
            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, newBook);
        }

        [TestMethod]
        public void Edit()
        {
            // Lets create a valid book objct to add into
            Book editedBook = new Book { ID = 1, Book1 = "new", AuthorName = "new", ISBN = "NA" };

            // Lets call the action method now
            controller.Edit(editedBook);

            // get the list of books
            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, editedBook);
        }

        [TestMethod]
        public void Delete()
        {
            // Lets call the action method now
            controller.Delete(1);

            // get the list of books
            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.DoesNotContain(books, book1);
        }
    }
}
