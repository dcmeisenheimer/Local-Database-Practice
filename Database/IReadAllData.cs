using System;
using System.Collections.Generic;

namespace LocalDatabaseVideo.Database
{
    public interface IReadAllData //Interface to allow class to read all data 
    {
        public List<Book> GetAllBooks();
    }
}
