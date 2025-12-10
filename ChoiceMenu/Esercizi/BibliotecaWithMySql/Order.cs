using MySql.Data.MySqlClient;

namespace BibliotecaWithMySql
{
    public enum TipoProdotto
    {
        dvd,
        libro,
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

        private Order(){}

        public void OrderById(int scelta)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = $"SELECT id, titolo FROM libri WHERE libri.id = {scelta}";
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
        }
    }
}