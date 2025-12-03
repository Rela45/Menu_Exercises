using System.ComponentModel;

namespace Biblioteca
{
    public class Order
    {
        public static  List<Documents> _items;
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

        public static void getListOfAllProducts()
        {
            //im hardcoding for now cause i was plannig to use sql but i need to train with javascript and jsons
            DVD dvd1 = new DVD("1", "NapoliRinascita", 2010, 10, true, 20);
            Books book1 = new Books("2", "Il migliore amico di mio fratello", 2014, 15, true, 1000);
            _items.Add(dvd1);
            _items.Add(book1);

            foreach(Documents d in _items)
            {
                Console.WriteLine($"This are the currently available products");
                Console.WriteLine(d);
            }
        }
        private Order(){Console.WriteLine($"deny external creation");}  
        
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