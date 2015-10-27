using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingMVC.Models;

namespace UnitTestingMVC.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public HomeController() 
            : this(new UnitOfWork())
        {

        }

        public HomeController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Book> books = unitOfWork.BookRepository.GetAllBooks();

            return View(books);
            
        }

        public ActionResult Details(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookByID(id);

            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BookRepository.AddBook(book);
                unitOfWork.BookRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookByID(id);

            return View(book);
        }


        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BookRepository.UpdateBook(book);
                unitOfWork.BookRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookByID(id);
            unitOfWork.BookRepository.DeleteBook(book);
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            Book book = unitOfWork.BookRepository.GetBookByID(id);
            unitOfWork.BookRepository.DeleteBook(book);
            unitOfWork.BookRepository.Save();
            return View("Deleted");
        }

        public ActionResult Deleted()
        {
            return View();
        }

    }
}