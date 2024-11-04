using System.Collections.Generic;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace Inlämningsuppgift3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string dataJSONFilePath = "LibraryData.json";
            string allDataAsJSONType = File.ReadAllText(dataJSONFilePath);

            MiniDB miniDB = JsonSerializer.Deserialize<MiniDB>(allDataAsJSONType)!;

            Library library = new Library();

            bool running = true;

            Console.WriteLine("Välkommen till det lilla Bilioteket");
            while (running)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Lägg till en ny bok");
                Console.WriteLine("2. Lägg till en ny författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort en bok");
                Console.WriteLine("6. Ta bort en författare");
                Console.WriteLine("7. Lista alla böcker och författare");
                Console.WriteLine("8. Sök och filtrera böcker");
                Console.WriteLine("9. Ge betyg till en bok");
                Console.WriteLine("10. Avsluta");

                string choosedOpptionByUser = Console.ReadLine()!;

                switch (choosedOpptionByUser)
                {
                    case "1":
                        library.AddNewBook(miniDB.AllBooksFromListInJSON, miniDB.AllAuthorsFromJson);
                        Console.Clear();
                        break;
                    case "2":
                        library.AddNewAuthor(miniDB.AllAuthorsFromJson);
                        Console.Clear();
                        break;
                    case "3":
                        library.UpdateBookDetails(miniDB.AllBooksFromListInJSON);
                        Console.Clear();
                        break;
                    case "4":
                        library.UpdateAuthorDetails(miniDB.AllAuthorsFromJson);
                        Console.Clear();
                        break;
                    case "5":
                        library.RemoveBookFromList(miniDB.AllBooksFromListInJSON);
                        Console.Clear();
                        break;
                    case "6":
                        library.RemoveAuthorFromList(miniDB.AllAuthorsFromJson);
                        Console.Clear();
                        break;
                    case "7":
                        library.ListAllBooksAndAuthors(miniDB.AllBooksFromListInJSON, miniDB.AllAuthorsFromJson);
                        Console.Clear();
                        break;
                    case "8":
                        library.SerchForAndFilterBooks(miniDB.AllBooksFromListInJSON);
                        Console.Clear();
                        break;
                    case "9":
                        library.RateABook(miniDB.AllBooksFromListInJSON);
                        Console.Clear();
                        break;
                    case "10":
                        Console.Clear();
                        Console.WriteLine("Avslutar...");
                        SaveNewDataToJSONFile(miniDB, dataJSONFilePath);
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltligt val");
                        break;
                }
            }
        }
        static void SaveNewDataToJSONFile(MiniDB miniDB, string dataJSONFilePath)
        {
            string updatedMiniDB = JsonSerializer.Serialize(miniDB, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataJSONFilePath, updatedMiniDB);
        }
    }
}
