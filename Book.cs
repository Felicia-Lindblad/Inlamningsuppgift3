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
        public List<int> Rating { get; set; }
        public Author Author { get; set; }

        public Book (string title, int id, string genre, int yearpublished, int isbn, Author author, List<int> rating)
        {
            Title = title;
            Id = id;
            Genre = genre;
            YearPublished = yearpublished;
            ISBN = isbn;
            Author = author;
            Rating = rating;
        }
    }
}
