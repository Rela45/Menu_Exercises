namespace Infrastructure
{
    using System.Collections.Generic;
    using Domain;
    #region InMemoryProduct
    /// <summary>
    /// Gestisco le classi concrete delle interfacce, utilizzo i loro metodi e poi li richiamo dove servono
    /// </summary>
    public class InMemoryProductRepo : IProductRepository
    {
        private readonly Dictionary<string, Product> _memorizedProducts = new(StringComparer.OrdinalIgnoreCase);
        public void Add(Product product)
        {
            _memorizedProducts[product.Code] = product;
        }

        public Product? GetByCode(string code)
        {
            _memorizedProducts.TryGetValue(code, out var product);
            return product;
        }

        public IEnumerable<Product> List()
        {
            return _memorizedProducts.Values;
        }
    }
    #endregion

    #region InMemoryOrder

    public class InMemoryOrderRepo : IOrderRepository
    {
        private readonly Dictionary<int, Order> _memorizedOrders = new();
        public void Add(Order order)
        {
            _memorizedOrders[order.Id] = order;
        }

        public Order? GetById(int id)
        {
            _memorizedOrders.TryGetValue(id, out var order);
            return order;
        }

        public IEnumerable<Order> List()
        {
            return _memorizedOrders.Values;
        }

        public void Update(Order order)
        {
            Console.WriteLine($"Update dell'ordine riuscito {_memorizedOrders[order.Id]} = {order}");
        }
        #endregion

        #region ServiceNotification
        public class ConsoleNotification : INotificationService
        {
            public void Send(string subject, string body)
            {
                Console.WriteLine($"[NOTIFICA]: {subject}\n{body}");
            }
        }
        #endregion
    }
}