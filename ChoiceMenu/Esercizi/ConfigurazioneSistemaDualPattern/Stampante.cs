class Stampante : IDispositivo
{
    public void Avvia()
    {
        Console.WriteLine($"La stampante si avvia");
        
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo: stampante");
        
    }
}