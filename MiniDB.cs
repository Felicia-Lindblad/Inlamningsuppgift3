using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inlämningsuppgift3
{
    public class MiniDB
    {
        [JsonPropertyName("Books")]
        public List<Book> AllBooksFromListInJSON {  get; set; }

        [JsonPropertyName("Authors")]
        public List<Author> AllAuthorsFromJson { get; set; }
    }
}
