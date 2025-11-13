public class ConcreteAuto : IVeicolo
{
    public void Start()
    {
        Console.WriteLine($"Avvio dell'auto");
    }
    public void ShowType()
    {
        Console.WriteLine($"Tipo : auto");
    }
}