using System;
using System.Data.SQLite;
using LocalDatabaseVideo.Database;
using System.Collections.Generic;

namespace LocalDatabaseVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            // string cs = @"URI =file:C:\Source\FallRepos\LocalDatabaseVideo\book.db";

            // //using represents it will close when its out of bounds so its not always running
            // using var con = new SQLiteConnection(cs); //var lets the system define the variable

            // //opens the connection
            // con.Open();

            // string stm = "select SQLITE_VERSION()"; //checks what version of SQL is running

            // using var cmd = new SQLiteCommand(stm, con); //both the statement and connection string thatll be used

            // string version = cmd.ExecuteScalar().ToString(); //turns the cmd prompt to a string

            // System.Console.WriteLine($"SQLit Version: {version}"); //tells us what version our sql lite is

            //ISeedData saveObject = new SaveData(); //seeding the data
            SaveData saveObject = new SaveData(); //seeding the data
            saveObject.SeedData();

            IReadAllData readObject = new ReadData();
            List<Book> allBooks = readObject.GetAllBooks(); //calls the method to store all books in the list


            foreach(Book book in allBooks) //prints all stored books
            {
                System.Console.WriteLine(book.ToString());
            }
            allBooks[0].Title = "The Final Empire"; //updates the first book due to place 0
            saveObject.SaveBook(allBooks[0]); //Updates the Title of book

            System.Console.WriteLine($"\nAfter the update");

            foreach(Book book in allBooks) //prints all stored books after update
            {
                System.Console.WriteLine(book.ToString());
            }
        }
    }
}
