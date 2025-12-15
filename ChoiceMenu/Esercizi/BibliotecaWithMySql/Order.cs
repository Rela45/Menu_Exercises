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
        {
            Console.WriteLine("Do you want to order a dvd or a book?");
            string? rawChoice = Console.ReadLine()?.Trim().ToLower();

            if (!Enum.TryParse<TipoProdotto>(rawChoice, ignoreCase: true, out TipoProdotto result))
            {
                Console.WriteLine("No existing products found");
                return;
            }

            Console.WriteLine("Insert the id of the product:");
            if (!int.TryParse(Console.ReadLine(), out int userValue))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            switch (result)
            {
                case TipoProdotto.book:
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        string query = "SELECT id, titolo FROM libri WHERE id = @id";
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", userValue);
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
                        string query = "SELECT id, titolo FROM dvd WHERE id = @id";
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", userValue);
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

        public void OrderByTitle()
        {
            Console.WriteLine("Do you want to order a dvd or a book?");
            string? choice = Console.ReadLine();
            if (!Enum.TryParse(choice, ignoreCase: true, out TipoProdotto result))
            {
                Console.WriteLine("No existing products found");
                return;
            }

            Console.WriteLine("Insert the title of the product:");
            string? userValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userValue))
            {
                Console.WriteLine("Invalid title");
                return;
            }

            // Normalize input: trim and collapse multiple spaces to single
            userValue = string.Join(" ", userValue.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));

            // We'll compare LOWER(REPLACE(titolo,' ',''))
            string query;
            switch (result)
            {
                case TipoProdotto.book:
                    query = "SELECT id, titolo FROM libri WHERE REPLACE(LOWER(titolo), ' ', '') = REPLACE(LOWER(@title), ' ', '')";
                    break;

                case TipoProdotto.dvd:
                    query = "SELECT id, titolo FROM dvd WHERE REPLACE(LOWER(titolo), ' ', '') = REPLACE(LOWER(@title), ' ', '')";
                    break;

                default:
                    Console.WriteLine("Error: choice has failed to be loaded");
                    return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", userValue);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            bool found = false;
                            while (reader.Read())
                            {
                                found = true;
                                int id = reader.GetInt32("id");
                                string? titolo = reader.GetString("titolo");
                                Console.WriteLine($"Id: {id}, Titolo: {titolo}");
                            }

                            if (!found)
                                Console.WriteLine("No products matched that title.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }
    }
}