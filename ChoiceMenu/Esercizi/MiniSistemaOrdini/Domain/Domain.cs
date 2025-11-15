namespace Domain
{
    public sealed class Configurazione
{
    private static readonly Lazy<Configurazione> _lazy =
        new Lazy<Configurazione>(() => new Configurazione());

    public static Configurazione Instance => _lazy.Value;

    public decimal TaxRate { get; } = 0.22m;
    public string Currency { get; } = "EUR";

    private Configurazione() { }
}

    public enum OrderStatus { New, Paid, Shipped, Cancelled }
    public record Product(string Code, string Name, decimal Price);

    public record OrderItem(Product Product, int Quantity)
    {
        public decimal LineTotal => Product.Price * Quantity;
    }

    #region Entities
    public class Order
    {
        public int Id { get; set; }
        public decimal Prezzo { get; set; }
        public string? Customer{ get; set; }
        

        public OrderStatus Status { get; private set; } = OrderStatus.New;
        private readonly List<OrderItem> _items = new();

        public Order(string customer)
        {
            Customer = customer;
        }

        public void AddItems(Product p, int quantity)
        {
            if (Status != OrderStatus.New) throw new InvalidOperationException("Puoi aggiungere un ordine soltanto in stato NEW");
            if (quantity <= 0) throw new ArgumentException("La quantita deve essere maggiore di 0");
            _items.Add(new OrderItem(p, quantity));
        }

        

        public void Pay()
        {
            if (Status != OrderStatus.New) { Console.WriteLine($"Puoi pagare solo ordini nuovi"); }
            Status = OrderStatus.Paid;
        }

        public void Ship()
        {
            if (Status != OrderStatus.Paid)
            {
                Console.WriteLine($"Solo ordini pagati possono essere spediti");
            }
            Status = OrderStatus.Shipped;
        }
        public void Cancel()
        {
            if (Status != OrderStatus.Shipped)
            {
                Console.WriteLine("Non puoi annullare un ordine gia spedito");
            }
            Status = OrderStatus.Cancelled;
        }

        public decimal SubTotal() => _items.Sum(i => i.LineTotal);

    }

    #endregion
    #region Interfaces
    public interface IOrderRepository
    {
        Order? GetById(int id);
        void Add(Order order);
        void Update(Order order);
        IEnumerable<Order> List();
    }

    public interface IProductRepository
    {
        Product? GetByCode(string code);
        void Add(Product product);
        IEnumerable<Product> List();
    }

    public interface INotificationService
    {
        void Send(string subject, string body);
    }

    public interface IConfigurationProvider
    {
        decimal TaxRate { get; }
        string Currency { get; }
    }
    #endregion

}