using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace TddMVCSampleApp.Models
{
    public class BookRepository : IBookRepository
    {
        SchoolDBEntities entities = null;

        public BookRepository(SchoolDBEntities entities)
        {
            this.entities = entities;
        }

        public List<Book> GetAllBooks()
        {
            return entities.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return entities.Books.SingleOrDefault(book => book.ID == id);
        }

        public void AddBook(Book book)
        {
            entities.Books.Add(book);
            Save();
        }

        public void UpdateBook(Book book)
        {

            entities.Entry(book).State = EntityState.Modified;
            Save();
        }

        public void DeleteBook(Book book)
        {
            entities.Books.Remove(book);
            Save();
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}