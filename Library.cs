using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Inlämningsuppgift3
{
    public class Library
    {
        public void RateABook(List<Book> allBooks)
        {
            allBooks.ForEach(book => Console.WriteLine($"ID: {book.Id} Titel: {book.Title}"));
            Console.WriteLine("Välj en bok du vill ge ett betyg till");
            Console.Write("Bokens ID:");
            int bookIDChoosen = Convert.ToInt32(Console.ReadLine());

            Book chosenBook = allBooks.FirstOrDefault(book => book.Id == bookIDChoosen)!;

            if (chosenBook == null)
            {
                Console.WriteLine("Boken hittades inte");
            }
            else
            {
                Console.Write("Vilket betyg vill du ge boken:");
                int newRating = Convert.ToInt32(Console.ReadLine());

                if (newRating < 1 || newRating > 5)
                {
                    Console.WriteLine("Betyget måste vara mellan 1 och 5.");
                }
                else
                {
                    chosenBook.Rating.Add(newRating);
                    Console.WriteLine($"Tack! Ditt betyg {newRating} har lagts till för boken '{chosenBook.Title}'.");
                }
            }

        }
        public void AddNewBook(List<Book> allBooks)
        {
            Console.Write("Bokens titel: ");
            string titleForNewBook = Console.ReadLine()!;
            Console.Write("Bokens ID: ");
            int idForNewBook = Convert.ToInt32(Console.ReadLine())!;
            Console.Write("Bokens genre: ");
            string genreForNewBook = Console.ReadLine()!;
            Console.Write("Bokens publisering år: ");
            int yearpublishedForNewBook = Convert.ToInt32(Console.ReadLine())!;
            Console.Write("Bokens ISBN: ");
            int isbnForNewBook = Convert.ToInt32(Console.ReadLine())!;
            Console.Write("ID för bokens författare: ");
            int AuthorIDForNewBook = Convert.ToInt32(Console.ReadLine())!;

            Book newBookToAdd = new Book(idForNewBook, titleForNewBook, genreForNewBook, yearpublishedForNewBook, isbnForNewBook, AuthorIDForNewBook);
            bool isbnAlreadyExcist = allBooks.Any(book => book.ISBN == newBookToAdd.ISBN);

            if (isbnAlreadyExcist)
            {
                Console.WriteLine($"En bok med ISBN {isbnForNewBook} finns redan");
            }
            else
            {
                allBooks.Add(newBookToAdd);
                Console.WriteLine("Boken har lagts till i biblioteket.");
            }
        }

        public void AddNewAuthor(List<Author> allAuthors)
        {
            Console.Write("Författarens namn: ");
            string nameForNewAuthor = Console.ReadLine()!;
            Console.Write("Författarens ID: ");
            int IDForNewAuthor = Convert.ToInt32(Console.ReadLine())!;
            Console.Write("Författarens land: ");
            string countryForNewAuthor = Console.ReadLine()!;

            Author newAuthorToAdd = new Author(IDForNewAuthor, nameForNewAuthor, countryForNewAuthor);
            bool AuthorIDAlreadyExcist = allAuthors.Any(author => author.Id == IDForNewAuthor);

            if (AuthorIDAlreadyExcist)
            {
                Console.WriteLine($"En författare med ID {IDForNewAuthor} finns redan");
            }
            else
            {
                allAuthors.Add(newAuthorToAdd);
                Console.WriteLine("Författaren har lagts till");
            }
        }

        public void UpdateBookDetails(List<Book> allBooks)
        {
            Console.WriteLine("Vilken bok vill du uppdatera?");
            allBooks.ForEach(book => Console.WriteLine($"ID: {book.Id} Titel: {book.Title}"));

            Console.Write("Skriv in bok ID på boken du vill uppdatera:");
            int bookToUpdateByID = Convert.ToInt32(Console.ReadLine())!;
            var bookToUpdate = allBooks.FirstOrDefault(book => book.Id == bookToUpdateByID);

            if (bookToUpdate == null)
            {
                Console.WriteLine("Boken kunde inte hittas");
            }

            Console.WriteLine("Vad vill du uppdatera?");
            Console.WriteLine("1. Titel");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. År publicerad");
            Console.WriteLine("4. ISBN");
            Console.Write("Ange ditt val: ");
            string updateChoiceByUser = Console.ReadLine()!;

            switch (updateChoiceByUser)
            {
                case "1":
                    Console.Write("Ange ny titel: ");
                    bookToUpdate.Title = Console.ReadLine()!;
                    break;
                case "2":
                    Console.Write("Ange ny genre: ");
                    bookToUpdate.Genre = Console.ReadLine()!;
                    break;
                case "3":
                    Console.Write("Ange nytt publiceringsår: ");
                    bookToUpdate.YearPublished = Convert.ToInt32(Console.ReadLine()!);
                    break;
                case "4":
                    Console.Write("Ange nytt ISBN: ");
                    bookToUpdate.ISBN = Convert.ToInt32(Console.ReadLine()!);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    return;
            }
            Console.WriteLine("Boken har uppdaterats!!");
        }

        public void UpdateAuthorDetails(List<Author> allAuthors)
        {
            Console.WriteLine("Vilken författare vill du uppdatera?");
            allAuthors.ForEach(author => Console.WriteLine($"ID: {author.Id} Namn: {author.Name}"));

            Console.Write("Skriv in författarID på den författare du vill uppdatera:");
            int authorToUpdateByID = Convert.ToInt32(Console.ReadLine())!;
            var authorToUpdate = allAuthors.FirstOrDefault(author => author.Id == authorToUpdateByID);

            if (authorToUpdate == null)
            {
                Console.WriteLine("Författaren kunde inte hittas");
            }

            Console.WriteLine("Vad vill du uppdatera?");
            Console.WriteLine("1. Namn");
            Console.WriteLine("2. ID");
            Console.WriteLine("3. Land");
            Console.Write("Ange ditt val: ");
            string updateChoiceByUser = Console.ReadLine()!;

            switch (updateChoiceByUser)
            {
                case "1":
                    Console.Write("Ange nytt namn: ");
                    authorToUpdate.Name = Console.ReadLine()!;
                    break;
                case "2":
                    Console.Write("Ange nytt ID: ");
                    authorToUpdate.Id = Convert.ToInt32(Console.ReadLine()!);
                    break;
                case "3":
                    Console.Write("Ange nytt land: ");
                    authorToUpdate.Country = (Console.ReadLine())!;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    return;
            }
            Console.WriteLine("Författaren har uppdaterats!!");
        }

        public void RemoveBookFromList(List<Book> allBooks)
        {
            allBooks.ForEach(book => Console.WriteLine($"ID: {book.Id} Titel: {book.Title}"));
            Console.Write("Skriv bokID på boken du vill ta bort:");
            int bookToRemoveByIDUserChoice = Convert.ToInt32(Console.ReadLine()!);

            var bookToRemove = allBooks.FirstOrDefault(book => book.Id == bookToRemoveByIDUserChoice);
            if (bookToRemove == null)
            {
                Console.WriteLine("Boken hittades inte");
            }
            else
            {
                allBooks.Remove(bookToRemove);
                Console.WriteLine($"Boken {bookToRemove.Title} har tagits bort");
            }
        }
        public void RemoveAuthorFromList(List<Author> allAuthors)
        {
            allAuthors.ForEach(author => Console.WriteLine($"ID: {author.Id} Namn: {author.Name}"));
            Console.Write("Skriv FörfattarID på författaren du vill ta bort:");
            int authorToRemoveByIDUserChoice = Convert.ToInt32(Console.ReadLine()!);

            var authorToRemove = allAuthors.FirstOrDefault(author => author.Id == authorToRemoveByIDUserChoice);
            if (authorToRemove == null)
            {
                Console.WriteLine("Boken hittades inte");
            }
            else
            {
                allAuthors.Remove(authorToRemove);
                Console.WriteLine($"Författaren {authorToRemove.Name} har tagits bort");
            }
        }
        public void ListAllBooksAndAuthors(List<Book> allBooks, List<Author> allAuthors)
        {
            Console.WriteLine("Böcker:");
            allBooks.ForEach(book => { double averageRatingForEachBook = book.Rating.Count > 0 ? book.Rating.Average() : 0;
            Console.WriteLine($"ID: {book.Id} Titel: {book.Title} Genre: {book.Genre} Year Published: {book.YearPublished} ISBN: {book.ISBN} Genomsnittligt betyg: {averageRatingForEachBook}");
            });

            Console.WriteLine("Författare:");
            allAuthors.ForEach(author => {
                var booksByAuthor = allBooks.Where(book => book.AuthorID == author.Id);
                string bookTitles = string.Join(", ", booksByAuthor.Select(book => book.Title));
                Console.WriteLine($"ID: {author.Id} Namn: {author.Name} Land: {author.Country} Skrivna böcker: {bookTitles}");
            });
        }
        public void SerchForAndFilterBooks(List<Book> allBooks)
        {
            Console.WriteLine("Välj ett val i menyn:");
            Console.WriteLine("1. Filtrera böcker enligt Genre");
            Console.WriteLine("2. Lista alla böcker enligt betyg");
            Console.WriteLine("3. Sortera böcker enligt publiceringsår");
            string userChoiceFromMenu = Console.ReadLine()!;

            switch (userChoiceFromMenu)
            {
                case "1":
                    Console.Write("Vilken Genre vill du sortera efter:");
                    string sortGenreChoosenByUser = Console.ReadLine()!;

                    var booksByGenre = allBooks.Where(book => book.Genre.Equals(sortGenreChoosenByUser, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (booksByGenre == null) 
                    {
                        Console.WriteLine("Genren hittades inte");
                    }
                    else
                    {
                        booksByGenre.ForEach(book => Console.WriteLine(book.Title));
                    }
                    break;
                case "2":
                    Console.Write("Välj vilket genomsnitligt betyg boken lägst ska ha mellan 1-5:");
                    int minRatingByUser = Convert.ToInt32(Console.ReadLine()!);

                    Console.WriteLine($"Böcker med ett genomslittligt betyg på {minRatingByUser} eller högre:");
                    if (minRatingByUser < 1 || minRatingByUser > 5)
                    {
                        Console.WriteLine("Oglitligt betyg. Ange ett betyg mellan 1 - 5");
                    }
                    else
                    {
                        var booksByRating = allBooks
                        .Where(book => book.Rating.Count > 0 && book.Rating.Average() >= minRatingByUser)
                        .OrderByDescending(book => book.Rating.Average())
                        .ToList();

                        if (booksByRating.Count == 0)
                        {
                            Console.WriteLine("Inga böcker hittades med detta betygskriterium.");
                        }
                        else
                        {
                            booksByRating.ForEach(book => Console.WriteLine($"{book.Title} - Genomsnittligt betyg: {book.Rating.Average():0.0}"));
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Böcker soreterat efter publiceringsår:");
                    var booksByYear = allBooks.OrderBy(book => book.YearPublished).ToList();
                    booksByYear.ForEach(book => Console.WriteLine($"{book.Title} - Publiceringsår: {book.YearPublished}"));
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }
}
