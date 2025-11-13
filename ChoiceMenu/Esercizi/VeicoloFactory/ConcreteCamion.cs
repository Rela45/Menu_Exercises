public class ConcreteCamion : IVeicolo
{
    public void Start()
    {
        Console.WriteLine($"Avvio del camion");
    }
    public void ShowType()
    {
        Console.WriteLine($"Tipo : camion");
    }
}