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
                        Console.Clear();
                        library.AddNewBook(miniDB.AllBooksFromListInJSON);                        
                        break;
                    case "2":
                        Console.Clear();
                        library.AddNewAuthor(miniDB.AllAuthorsFromJson);
                        break;
                    case "3":
                        Console.Clear();
                        library.UpdateBookDetails(miniDB.AllBooksFromListInJSON);
                        break;
                    case "4":
                        Console.Clear();
                        library.UpdateAuthorDetails(miniDB.AllAuthorsFromJson);
                        break;
                    case "5":
                        Console.Clear();
                        library.RemoveBookFromList(miniDB.AllBooksFromListInJSON);
                        break;
                    case "6":
                        Console.Clear();
                        library.RemoveAuthorFromList(miniDB.AllAuthorsFromJson);
                        break;
                    case "7":
                        Console.Clear();
                        library.ListAllBooksAndAuthors(miniDB.AllBooksFromListInJSON, miniDB.AllAuthorsFromJson);
                        break;
                    case "8":
                        Console.Clear();
                        library.SerchForAndFilterBooks(miniDB.AllBooksFromListInJSON);
                        break;
                    case "9":
                        Console.Clear();
                        library.RateABook(miniDB.AllBooksFromListInJSON);
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
