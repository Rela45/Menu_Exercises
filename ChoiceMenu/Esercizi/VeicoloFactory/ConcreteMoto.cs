public class ConcreteMoto : IVeicolo
{
    public void Start()
    {
        Console.WriteLine($"Avvio della Moto");
    }
    public void ShowType()
    {
        Console.WriteLine($"Tipo : Moto");
    }
}
