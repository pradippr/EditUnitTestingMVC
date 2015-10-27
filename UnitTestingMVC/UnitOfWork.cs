using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMVC.Models;

namespace UnitTestingMVC
{
    public class UnitOfWork
    {
        private BookDBContext db = null;
        public IBooksRepository BookRepository
        {
            get;
            private set;
        }

        public UnitOfWork()
        {
            db = new BookDBContext();
            BookRepository = new BookRepository(db);           
        }


        public UnitOfWork(IBooksRepository bookRepo)
        {
            BookRepository = bookRepo;
        }

       
    }
}
