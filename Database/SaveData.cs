using System;
using System.Data.SQLite;

namespace LocalDatabaseVideo.Database
{
    public class SaveData : ISeedData, ISaveData //adding data to the database and inherits from ISaveData
    {
        public void SaveBook(Book value) //save book method for the int ISaveData Interface
        {
            string cs = @"URI =file:C:\Source\FallRepos\LocalDatabaseVideo\book.db"; //same as SeedData MEthod
            
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"UPDATE books set title = @title, author = @author where id = @id"; //place holder to update books
            cmd.Parameters.AddWithValue("@id", value.Id); //pass the book value in the field and sets the parameter
            cmd.Parameters.AddWithValue("@title", value.Title); //pass the book value in the field and sets the parameter
            cmd.Parameters.AddWithValue("@author", value.Author); //pass the book value in the field and sets the parameter

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void SeedData() //Purpose is to get the intial data out there. Throws away old data and starts over
        {
            string cs = @"URI =file:C:\Source\FallRepos\LocalDatabaseVideo\book.db";
            
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS books"; 
            cmd.ExecuteNonQuery(); //use execute non query when you are not expecting data back

            cmd.CommandText = @"CREATE TABLE books(id INTEGER PRIMARY KEY, title TEXT, author TEXT)"; //Creates the table the primary key will auto increment the id for us after searching the highest ID
            cmd.ExecuteNonQuery(); //not retrieving data so it executes

            cmd.CommandText = @"INSERT INTO books (title, author) VALUES(@title, @author)"; //we dont insert id because its auto incrementing and the database does it for us the VALUES is just a place holder
            cmd.Parameters.AddWithValue("@title", "Mistborn"); //adds the values for the parameters
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");

            cmd.Prepare(); //gets our perameters inserted for us
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (title, author) VALUES(@title, @author)"; //we dont insert id because its auto incrementing and the database does it for us the VALUES is just a place holder
            cmd.Parameters.AddWithValue("@title", "Oathbringer"); //adds the values for the parameters
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");

            cmd.Prepare(); //gets our perameters inserted for us
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (title, author) VALUES(@title, @author)"; //we dont insert id because its auto incrementing and the database does it for us the VALUES is just a place holder
            cmd.Parameters.AddWithValue("@title", "Dragon Reborn"); //adds the values for the parameters
            cmd.Parameters.AddWithValue("@author", "Robert Jordan");

            cmd.Prepare(); //gets our perameters inserted for us
            cmd.ExecuteNonQuery();

        }
    }
}
