namespace Biblioteca
{
    public class MainMenu
    {
        public static void Run()
        {
            
            bool loop;
            Console.WriteLine($"Benvenuti al Menu della Biblioteca, vuoi effettuare un ordine? \n1. Si \n2. No");
            string? doLoop = Console.ReadLine();
            if (doLoop == "1")
            {
                loop = true;
                Console.WriteLine($"inserisci il tuo nome");
                string? name = Console.ReadLine();
                Console.WriteLine($"inserisci il tuo cognome");
                string? surname = Console.ReadLine();
                Console.WriteLine($"inserisci la tua email");
                string? email = Console.ReadLine();
                Console.WriteLine($"inserisci la password");
                string? psw = Console.ReadLine();
                List<User> listOfUsers = new List<User>
                {
                    new User(name,surname,email,psw)
                };
                while (loop)
                {
                    Console.WriteLine($"===========Menu===========\n1. Display di tutti i prodotti\n2. Ordina prodotto per Id\n3. Ordina prodotto per titolo\n4. Esci");
                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Order.Instance.getListOfAllProducts();
                            break;
                        case "2":
                            Console.WriteLine($"inserisci id");
                            int x = Convert.ToInt32(Console.ReadLine());
                            Order.Instance.OrderById(x);
                            break;   
                        case "3":
                            Console.WriteLine($"inserisci il titolo");
                            string? title = Console.ReadLine();
                            Order.Instance.OrderByTitle(title);
                            break;
                        case "4":
                            loop = false;
                            break;
                        default:
                            Console.WriteLine($"Hai effettuato una scelta sbagliata, ritenta");
                            break;
                            
                    }
                    
                    
                }
            }
            else if (doLoop == "2") return;



        }

    }
}

