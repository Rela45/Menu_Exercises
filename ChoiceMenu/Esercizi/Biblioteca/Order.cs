using System.ComponentModel;

namespace Biblioteca
{
    public class Order
    {
        public static  List<Documents> _items = new List<Documents>
        {
            new DVD(1, "NapoliRinascita", 2010, 10, true, 20),
            new Books(2, "Il migliore amico di mio fratello", 2014, 15, true, 1000)
        };
        
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

        

        public  void getListOfAllProducts()
        {
            Console.WriteLine($"This are the currently available products");
            foreach(Documents d in _items)
            {
                Console.WriteLine(d);
            }
        }

        public  Documents OrderById(int? id)
        {
            Console.WriteLine($"ordine effettuato con successo");
            return _items.FirstOrDefault(x => (x.Id == id));
        }
        public Documents OrderByTitle(string? title)
        {
            Console.WriteLine($"ordine effettuato con successo");
            return _items.FirstOrDefault(x => (x.Title == title));
            
        } 
        
        // public static Documents CreateOrderById(string id)
        // {
        //     switch (type.ToLower())
        //     {
        //         case "book":
        //             return new Books();
        //     }
        // }
    }
}