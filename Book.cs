using System;

namespace LocalDatabaseVideo
{
    public class Book //Book Class to hold properties of books
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}

        public override string ToString()
        {
            return Title + " written by " + Author;
        }
    }
}
