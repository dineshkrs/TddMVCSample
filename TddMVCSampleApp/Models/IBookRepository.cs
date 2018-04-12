using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TddMVCSampleApp.Models
{
    // This interface will give define a contract for CRUD operations on
    // Books entity
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        void Save();
    }
}