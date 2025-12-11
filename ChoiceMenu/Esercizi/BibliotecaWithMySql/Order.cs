using MySql.Data.MySqlClient;

namespace BibliotecaWithMySql
{
    public enum TipoProdotto
    {
        dvd,
        book,
    }
    public sealed class Order
    {
        static string connString = "server=localhost;user=root;password=110803Ilaria;database=test_libreria_vendite";

        private static Order _instance;

        public static Order Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Order();
                return _instance;
            }
        }

        private Order() { }

        public void OrderById()
        {//here i have to manage what type of order i want to do (dvd or book)
            Console.WriteLine($"Do you want to order a dvd or a book?");
            string? choice = Console.ReadLine();
            if (!Enum.TryParse(choice, ignoreCase: true, out TipoProdotto result))
            {
                Console.WriteLine($"No exisisting products found");
                return;
            }
            switch (result)
            {
                case TipoProdotto.book:
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        Console.WriteLine($"insert the id of the book");
                        int userValue = Convert.ToInt32(Console.ReadLine());
                        string query = $"SELECT id, titolo FROM libri WHERE libri.id = {userValue}";
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32("id");
                                    string? titolo = reader.GetString("titolo");
                                    Console.WriteLine($"Id: {id}, Titolo: {titolo}");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                    break;
                case TipoProdotto.dvd:
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        Console.WriteLine($"Insert the id of the dvd you want.");
                        int userValue = Convert.ToInt32(Console.ReadLine());
                        string query = $"SELECT id, titolo FROM dvd WHERE dvd.id = {userValue}";
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32("id");
                                    string? titolo = reader.GetString("titolo");
                                    Console.WriteLine($"Id: {id}, Titolo: {titolo}");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                    break;
            }
        }
    }
}