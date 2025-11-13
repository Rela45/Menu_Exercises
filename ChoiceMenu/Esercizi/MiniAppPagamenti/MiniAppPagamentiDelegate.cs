namespace MiniAppPagamenti
{
    


public enum TipoPagamento
{
    Carta,
    Paypal,
    Bonifico
}

#region Interfaces
public interface IPagamento
{
    string TipoPagamento{ get; }
    void PaymentProcess();
}

public interface ILogger
{
    void Log(string message);
}

public interface IDiscountPolicy
{
    void PolicyTaken();
}


#endregion

#region Classi Interfacce
public class PaymentPaypal : IPagamento
{
    public string TipoPagamento { get; set; } = "Paypal";

    public void PaymentProcess()
    {
        Console.WriteLine($"Pagamento con Paypal");
    }
}

public class PaymentBonifico : IPagamento
{
    public string TipoPagamento { get; set; } = "Bonifico";
    public void PaymentProcess()
    {
        Console.WriteLine($"Pagamento con Bonifico");
    }
}

public class PaymentCarta : IPagamento
{
    public string TipoPagamento { get; set; } = "Carta";
    public void PaymentProcess()
    {
        Console.WriteLine($"Pagamento con Carta");
    }
}

public class Notifier : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

#endregion


#region FACTORY

public static class PaymentFactory
{
    public static IPagamento CreatePayment(TipoPagamento tipo)
    {
        switch (tipo)
        {
            case TipoPagamento.Carta:
                return new PaymentCarta();
            case TipoPagamento.Paypal:
                return new PaymentPaypal();
            case TipoPagamento.Bonifico:
                return new PaymentBonifico();
            default:
                throw new ArgumentException("Tipo pagamento non supportato");
        }
    }
}

#endregion

#region Service
public class PaymentService
{
    private readonly IPagamento _payment;
    private readonly ILogger _logger;
    public PaymentService(IPagamento payment, ILogger logger)
    {
        _payment = payment;
        _logger = logger;
    }

    public void Pay()
    {
        _logger.Log("Nuovo");
        _payment.PaymentProcess();
    }

}


#endregion
#region MAIN
static class PagamentiMain
{
    public static void Run()
    {
        var tipo = TipoPagamento.Carta;
        var pagamento = PaymentFactory.CreatePayment(tipo);
        var logger = new Notifier();

        var service = new PaymentService(pagamento, logger);

        service.Pay();
        
    }
}

#endregion
}