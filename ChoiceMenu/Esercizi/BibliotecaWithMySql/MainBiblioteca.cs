
using System.IO.Pipes;
using MySql.Data.MySqlClient;

namespace BibliotecaWithMySql
{
    internal class MainBiblioteca
    {
        public int Anno { get; set; }
        public static void ReadAllDB()
        {
        // Using block ensures that the MySqlConnection is automatically closed/disposed
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            try
            {
                conn.Open(); // Opens connection to the database
                Console.WriteLine($"Connessione riuscita!");

                // Query to select all contacts from the table
                string query = "SELECT * FROM dvd";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Execute the query and obtain a data reader
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("===== Dvd presenti nello store =====");
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-15}| {3, -10} | {4, -7}", "ID", "Titolo", "Genere", "anno","regista");
                    Console.WriteLine(new string('-', 50));

                    // Iterate through all returned rows
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id"); // Reads the 'id' field (integer)
                        string? titolo = reader.GetString("titolo");
                        string? genere = reader.GetString("genere");
                        int anno = reader.GetInt32("anno");
                        string? regista = reader.GetString("regista");

                        // Print each row formatted as a table
                        Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3, -10} | {4, -7}", id, titolo, genere, anno, regista);
                    }
                    reader.Close(); // Closes the data reader
                    Console.WriteLine(new string('=', 50));
                }
                Console.WriteLine($"=======================================");
            }
            catch (Exception e)
            {
                // Handles errors such as connection or SQL issues
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
        static string connString = "server=localhost;user=root;password=110803Ilaria;database=test_libreria_vendite";
        public static void Run()
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine($"=====MENU====\n1. Visualizza tutti i prodotti");
                string? scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        ReadAllDB();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
