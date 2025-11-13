#region Interface
public interface IPaymentGateway
{
    void PaymentProcess();
}

#endregion

#region Implementation
public class PaypalGateway : IPaymentGateway
{
    public void PaymentProcess()
    {
        Console.WriteLine($"Payment with Paypal");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void PaymentProcess()
    {
        Console.WriteLine($"Payment with Stripe");
    }
}

#endregion

public class PaymentProcessor
{
    private readonly IPaymentGateway _payment;
    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _payment = paymentGateway;
    }

    public void CreatePayment()
    {
        _payment.PaymentProcess();
    }

}
#region MAIN 

static class PaymentProcessMain
{
    public static void Run()
    {
        Console.WriteLine($"Come desideri procedere col pagamento? (Paypal or Stripe)");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "paypal":
                IPaymentGateway paymentGateway = new PaypalGateway();
                PaymentProcessor paymentProcessor = new PaymentProcessor(paymentGateway);
                paymentProcessor.CreatePayment();
                break;
            case "stripe":
                IPaymentGateway paymentStripeGateway = new PaypalGateway();
                PaymentProcessor paymentProcessor2 = new PaymentProcessor(paymentStripeGateway);
                paymentProcessor2.CreatePayment();
                break;
            default:
                Console.WriteLine($"payment method not accepted");
                break;
        }
        Console.WriteLine($"premi un tasto per uscire");
        Console.ReadKey();
        
    }
}

#endregion