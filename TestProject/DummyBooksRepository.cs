﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMVC;
using UnitTestingMVC.Models;

namespace TestProject
{
    public class DummyBooksRepository : IBooksRepository
    {
        List<Book> m_books = null;

        public DummyBooksRepository(List<Book> books)
        {
            m_books = books;
        }

        public void AddBook(Book book)
        {
            m_books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            m_books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return m_books;
        }

        public Book GetBookByID(int id)
        {
            return m_books.SingleOrDefault(book => book.ID == id);
        }

        public void Save()
        {
           
        }

        public void UpdateBook(Book book)
        {
            int id = book.ID;
            Book bookToUpdate = m_books.SingleOrDefault(b => b.ID == id);
            DeleteBook(bookToUpdate);
            m_books.Add(book);
        }
    }
}
