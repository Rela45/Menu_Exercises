#region INTERFACE
using System.Runtime.CompilerServices;

public interface IGreeter
{
    void Greetings();
}
public interface ILogger
{
    void Log(string message);
}
#endregion

#region ConsoleGreeter
public class ConsoleGreeter : IGreeter
{
    public void Greetings()
    {
        Console.WriteLine($"Greetings!");
    }
}
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"LOG: {message}");
        
    }
}
#endregion

#region GreetingService 
public class GreetingService
{
    private readonly IGreeter _greeter; //implementazione interfaccia
    private readonly ILogger _logger;

    public GreetingService(IGreeter greeter, ILogger logger)
    {
        _greeter = greeter;
        _logger = logger;
    }

    public void CallGreetings()
    {
        _logger.Log("Ciao");
        _greeter.Greetings();
    }
}

#endregion
#region MAIN
static class GreetingServiceMain
{
    public static void Run()
    {
        IGreeter greeter = new ConsoleGreeter();
        ILogger logger = new ConsoleLogger();
        GreetingService greetingService = new GreetingService(greeter,logger);
        Console.WriteLine("---------------------------");
        greetingService.CallGreetings();
        Console.WriteLine("---------------------------");
    }
}


#endregion