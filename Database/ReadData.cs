using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LocalDatabaseVideo.Database
{
    public class ReadData : IReadAllData //List Class inherits from interface to store all data in a List of Books
    {
        public List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            string cs = @"URI =file:C:\Source\FallRepos\LocalDatabaseVideo\book.db";
            using var con = new SQLiteConnection(cs);

            con.Open();

            string stm = "SELECT * FROM books"; //selects all the fields from the table called books

            using var cmd = new SQLiteCommand(stm, con); 

            using SQLiteDataReader rdr = cmd.ExecuteReader(); //executes the reader

            while(rdr.Read()) //reads all the data to the book list
            {
                Book temp = new Book(){Id =  rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)}; //temp book that will read the data and hold it in the temp object. 0, 1, 2 are the places they are being held
                allBooks.Add(temp); //adds temp object to the allbooks 
                //option 2 which is the same thing

                //allBooks.Add(new Book(){Id =  rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)}); same thing as above method
            }
            return allBooks;
        }
    }
}
