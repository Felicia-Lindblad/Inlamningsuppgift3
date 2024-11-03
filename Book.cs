using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift3
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int YearPublished { get; set; }
        public int ISBN { get; set; }
        public List<double> Rating { get; set; }
        public int AuthorID { get; set; }

        Author Author { get; set; }

        public Book (int id, string title, string genre, int yearpublished,  int isbn, int authorID)
        {
            Id = id;
            Title = title;
            Genre = genre;
            YearPublished = yearpublished;
            ISBN = isbn;
            AuthorID = authorID;
            Rating = new List<double>();
        }
    }
}
