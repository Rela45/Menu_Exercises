#region ENUM
public enum TipoNotifica
{
    Email,
    Sms,
    Push,
}

#endregion

#region Interface
public interface INotifier
{
    void Send(string message);
}


#endregion
#region Implementation
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"{message} [inviato tramite EMAIL]");
    }
}

public class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"{message} [inviato tramite SMS]");
    }
}

public class PushNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"{message} :[Notifica Ricevuta correttamente]:");
    }
}
#endregion


#region Factory
public static class NotifierFactory
{
    public static INotifier CreateNotify(TipoNotifica tipo)
    {
        switch (tipo)
        {
            case TipoNotifica.Email:
                return new EmailNotifier();
            case TipoNotifica.Sms:
                return new SmsNotifier();
            case TipoNotifica.Push:
                return new PushNotifier();
            default:
                throw new NotSupportedException("Tipo notifica non supportata");
        }
    }

}

#endregion

#region Service
public class MessaggioService
{
    private readonly INotifier _notifier;

    public MessaggioService(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void MessageSent(string message)
    {
        _notifier.Send(message);
    }
}


#endregion
public static class MainNotifier
{
    public static void Run()
    {
        Console.WriteLine("Seleziona il tipo di notifica (Email, Sms, Push):");
        string? input = Console.ReadLine();

        if (!Enum.TryParse(input, ignoreCase: true, out TipoNotifica tipoNotifica))
        {
            Console.WriteLine("Tipo di notifica non valido.");
            return;
        }

        // Factory
        INotifier notifier = NotifierFactory.CreateNotify(tipoNotifica);
        var service = new MessaggioService(notifier);
        service.MessageSent("Ciao!");
    }
}

