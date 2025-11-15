namespace LayerApplication
{
    using Domain;
    #region ProductService
    public class ProductService
    {
        private readonly IProductRepository _products;

        public ProductService(IProductRepository products)
        { _products = products; }

        public void CreateProduct(string code, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Codice richiesto.");
            _products.Add(new Product(code, name, price));
        }

        public IEnumerable<Product> List() => _products.List();
        public Product Require(string code) => _products.GetByCode(code)
            ?? throw new InvalidOperationException("Prodotto inesistente.");
    }
    #endregion
    #region OrderService
    public class OrderService
    {
        private readonly ProductService productService;
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationService _notificationService;
        private readonly IConfigurationProvider _configurationProvider;

        public OrderService(ProductService productService, IOrderRepository orderRepository, INotificationService notificationService, IConfigurationProvider configurationProvider)
        {
            this.productService = productService;
            _orderRepository = orderRepository;
            _notificationService = notificationService;
            _configurationProvider = configurationProvider;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
            _notificationService.Send("Nuovo ordine creato", $"N.Ordine {order.Id}");
        }

    }
    #endregion

}

