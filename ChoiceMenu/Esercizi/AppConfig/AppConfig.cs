#region APPCONFIGSINGLETON
using System.Data.Common;
using System.Net.WebSockets;
namespace AppConfig{
public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _lazy = new(() => new AppConfig());

    public static AppConfig Instance => _lazy.Value;

    // Proprietà di configurazione globali
    public string NomeApplicazione { get; private set; }
    public string Valuta { get; private set; }
    public decimal AliquotaIVA { get; private set; }

    public void SceltaConfig()
    {
        Console.WriteLine($"Hai scelto la prima config");
    }
}


public sealed class AppConfig2
{
    private static readonly Lazy<AppConfig2> _lazy = new(() => new AppConfig2());

    public static AppConfig2 Instance => _lazy.Value;

    // Proprietà di configurazione globali
    public string NomeApplicazione { get; private set; }
    public string Valuta { get; private set; }
    public decimal AliquotaIVA { get; private set; }

    public void SceltaConfig()
    {
        Console.WriteLine($"Hai scelto la seconda config");
    }
}

#endregion

#region Class Order
public class Order
{
    public int Id { get; set; }
    public string Descrizione { get; set; } = "";
    public decimal Prezzo { get; set; }
}

#endregion
#region INTERFACE
public interface ILogger
{
    void Log(string message);
}
#endregion

#region Services
public class LoggerServices : ILogger
{
    private readonly AppConfig _config;
    private readonly AppConfig2 _secondConfig;
    public LoggerServices(AppConfig config)
    {
        _config = config;
    }
    public LoggerServices(AppConfig2 secondConfig)
    {
        _secondConfig = secondConfig;
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {_config.NomeApplicazione}: {message}");
    }
}


public class OrderService
{
    private readonly ILogger _logger;
    private readonly List<Order> _ordini = new();

    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void AggiungiOrdine(Order ordine)
    {
        _ordini.Add(ordine);
        _logger.Log($"Ordine #{ordine.Id} aggiunto: {ordine.Descrizione} - {ordine.Prezzo:0.00}");
    }

    public void StampaReport()
    {
        _logger.Log("== Report Ordini ==");
        foreach (var o in _ordini)
        {
            _logger.Log($"Ordine #{o.Id}: {o.Descrizione} - {o.Prezzo:0.00}");
        }
    }
}
#endregion
#region MAIN
static class AppconfigMain
{
    public static void Run(){

        var config = AppConfig.Instance;
        Console.WriteLine($"Scegli l'istanza di configurazione desiderata (1 o 2)");
        // int scelta = Convert.ToInt32()

        ILogger logger = new LoggerServices(config);

        var orderService = new OrderService(logger);

        bool continua = true;
        int i = 1;
        while (continua)
        {
            Console.WriteLine($"------MENU------");
            Console.WriteLine($"1. Aggiungi un ordine");
            Console.WriteLine($"2. Stampa il recap degli ordini");
            Console.WriteLine($"3. esci");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine($"Cosa vuoi ordinare?");
                    string? ordine = Console.ReadLine();
                    orderService.AggiungiOrdine(new Order { Id = i, Descrizione = ordine, Prezzo = 200 });
                    i++;
                    break;
                case "2":
                    orderService.StampaReport();
                    break;
                case "3":
                    continua = false;
                    break;
            }
        }
        Console.WriteLine($"Programma finito CORRETTAMENTE YEAH!!!");
        
    }
}

#endregion
}