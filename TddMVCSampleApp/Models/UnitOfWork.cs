using System;

namespace TddMVCSampleApp.Models
{
    public class UnitOfWork : IDisposable
    {
        private SchoolDBEntities entities = null;
        public UnitOfWork()
        {
            entities = new SchoolDBEntities();
            BookRepository = new BookRepository(entities);
        }

        public UnitOfWork(IBookRepository booksRepo)
        {
            BookRepository = booksRepo;
        }

        public IBookRepository BookRepository
        {
            get;
            private set;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                entities = null;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion

    }
}