using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TddMVCSampleApp.Models;

namespace TddMVCSampleApp.Controllers
{
    public class BooksController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public BooksController() : this(new UnitOfWork())
        { }
        public BooksController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }
        // GET: Books
        public ActionResult Index()
        {
            List<Book> books = unitOfWork.BookRepository.GetAllBooks();
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookById(id);
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    unitOfWork.BookRepository.AddBook(book);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View();
                }
            }

            return View();
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookById(id);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    unitOfWork.BookRepository.UpdateBook(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = unitOfWork.BookRepository.GetBookById(id);
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book book = unitOfWork.BookRepository.GetBookById(id);
                unitOfWork.BookRepository.DeleteBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
