
using System.IO.Pipes;
using MySql.Data.MySqlClient;
using Biblioteca;
using User = Biblioteca.User;
using AppConfig;
using Domain;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.Marshalling;

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
                    conn.Open();
                    Console.WriteLine("Connection extablished!");

                    string query =
                        "SELECT id, titolo, genere, autore AS creatore, 'LIBRO' AS tipo FROM libri " +
                        "UNION ALL " +
                        "SELECT id, titolo, genere, regista AS creatore, 'DVD' AS tipo FROM dvd;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine(new string('=', 40) + " Product in the store " + new string('=', 40));

                        Console.WriteLine(
                            "{0,-5} | {1,-30} | {2,-15} | {3,-25} | {4,-10}",
                            "ID", "Titolo", "Genere", "Autore/Regista", "Tipo"
                        );

                        Console.WriteLine(new string('-', 110));

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string titolo = reader.GetString("titolo");
                            string genere = reader.GetString("genere");
                            string creatore = reader.GetString("creatore");
                            string tipo = reader.GetString("tipo");

                            Console.WriteLine(
                                "{0,-5} | {1,-30} | {2,-15} | {3,-25} | {4,-10}",
                                id, titolo, genere, creatore, tipo
                            );
                        }

                        Console.WriteLine(new string('=', 110));
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

        }
        static string connString = "server=localhost;user=root;password=110803Ilaria;database=test_libreria_vendite";
        public static void Run()
        {
            bool loop = true;
            Console.WriteLine($"HI! Welcome in the store. ");
            
            Console.WriteLine($"Insert name");
            string? name = Console.ReadLine();
            Console.WriteLine($"Insert surname");
            string? surname = Console.ReadLine();
            Console.WriteLine($"Insert your email");
            string? email = Console.ReadLine();
            Console.WriteLine($"Insert a password");
            string? psw = Console.ReadLine();
            List<Biblioteca.User> listOfUsers = new List<Biblioteca.User>
            {
                new Biblioteca.User(name,surname,email,psw)
            };
            while (loop)
            {
                Console.WriteLine($"=========================MENU=============================\n1. Display all products\n2. Order Products by ID\n3. Order Product by title");
                string? scelta = Console.ReadLine();
                
                switch (scelta)
                {
                    case "1":
                        ReadAllDB();
                        break;
                    case "2":
                        Order.Instance.OrderById();
                        break;
                    case "3":
                        Order.Instance.OrderByTitle();
                        break;
                    case "4":
                        Console.WriteLine($"See you again!");
                        loop = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
