using System;
using MySql.Data.MySqlClient; // Library for connecting and executing commands on a MySQL database


internal static class MainSql
{
    // Connection string that defines how to connect to the MySQL database
    static string connString = "server=localhost;user=root;password=110803Ilaria;database=rubrica_db";
    #region MENU
    // Entry point of the program
    public static void Run()
    {
        bool continua = true; // Controls the loop for showing the menu

        while (continua) // Repeat menu until the user decides to exit
        {
            // Menu interface (kept in Italian)
            Console.WriteLine($"Inserisci il numero corrispondente all'operazione da eseguire");
            Console.WriteLine($"======MENU====== \n1.Inserisci un nuovo contatto \n2.Visualizza tutti i contatti \n3.Elimina un contatto tramite nome\n4.Esci dal programma");

            string? scelta = Console.ReadLine(); // Reads user input from console

            // Switch to execute different database operations
            switch (scelta)
            {
                case "1":
                    InsertContact(); // Calls the function that inserts a new record
                    break;
                case "2":
                    ReadAllDB(); // Calls the function that displays all records
                    break;
                case "3":
                    DeleteContact(); // Calls the function that deletes a record
                    break;
                case "4":
                    continua = false; // Exit the loop → program ends
                    break;
                default:
                    Console.WriteLine("input non valido");
                    break;
            }
        }
    }
#endregion
    #region Visualizza DB
    // Reads all records from the 'contatti' table and prints them in a formatted way
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
                string query = "SELECT * FROM contatti";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Execute the query and obtain a data reader
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("===== CONTATTI IN RUBRICA =====");
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-15}", "ID", "Nome", "Telefono");
                    Console.WriteLine(new string('-', 50));

                    // Iterate through all returned rows
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id"); // Reads the 'id' field (integer)
                        string nome = reader.GetString("nome"); // Reads the 'nome' field (string)
                        string telefono = reader.GetString("telefono"); // Reads the 'telefono' field (string)

                        // Print each row formatted as a table
                        Console.WriteLine("{0,-5} | {1,-20} | {2,-15}", id, nome, telefono);
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
#endregion
#region Inserimento
    // Inserts a new contact into the database
    public static void InsertContact()
    {
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            try
            {
                conn.Open(); // Opens connection
                Console.WriteLine($"Inserisci il nome da inserire in rubrica");
                string? nome = Console.ReadLine().Trim(); // Reads 'nome' from user input
                Console.WriteLine($"Inserisci il suo numero di telefono");
                string? telefono = Console.ReadLine().Trim(); // Reads 'telefono' from user input

                // SQL INSERT command using string interpolation
                string query = $"INSERT INTO contatti (nome , telefono) VALUES ('{nome}', '{telefono}')";

                // Prepares and executes the SQL command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery(); // Executes the command (no result set expected)

                Console.WriteLine($"Nuovo Utente Inserito!");
                Console.WriteLine($"=======================================");
            }
            catch (Exception e)
            {
                // Prints an error message if something goes wrong
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
    #endregion
#region Cancella
    // Deletes a contact from the database based on the name
    public static void DeleteContact()
    {
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            try
            {
                conn.Open(); // Opens database connection
                Console.WriteLine($"Inserisci il nome da eleminare in rubrica");
                string? nome = Console.ReadLine().Trim(); // Reads the name to delete

                // SQL DELETE statement — deletes record where 'nome' matches input
                string query = $"DELETE FROM contatti WHERE nome = '{nome}'";


                
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery(); // Executes the deletion
                
                Console.WriteLine($"Utente eliminato correttamente");
                Console.WriteLine($"=======================================");
                
            }
            catch (Exception e)
            {
                // Handles possible errors
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
#endregion