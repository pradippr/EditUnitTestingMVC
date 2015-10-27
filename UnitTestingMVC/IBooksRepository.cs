using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMVC.Models;

namespace UnitTestingMVC
{
    public interface IBooksRepository
    {
        List<Book> GetAllBooks();

        Book GetBookByID(int id);

        void AddBook(Book book);
        
        void UpdateBook(Book book);

        void DeleteBook(Book book);

        void Save();
    }
}
