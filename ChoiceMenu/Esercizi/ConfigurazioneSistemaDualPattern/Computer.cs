public class Computer : IDispositivo
{
    public void Avvia()
    {
        Console.WriteLine($"Il computer si avvia");
        
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo: computer");
        
    }
}