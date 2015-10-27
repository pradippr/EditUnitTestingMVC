using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMVC.Models;

namespace UnitTestingMVC
{
    class BookRepository : IBooksRepository
    {
        BookDBContext db = null;

        public BookRepository(BookDBContext db)
        {
            this.db = db;
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            db.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookByID(int id)
        {
            return db.Books.SingleOrDefault(book => book.ID == id);
        }

        public void Save()
        {
            db.SaveChanges(); ;
        }

        public void UpdateBook(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;            
        }
    }
}
