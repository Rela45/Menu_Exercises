class VeicoloConFactoryMethodMain
{
    public static void Run()
    {
        Console.WriteLine($"Inserisci il tipo di veicolo che vuoi creare");
        string? input = Console.ReadLine();
        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(input);
        veicolo.Start();
        veicolo.ShowType();
    }
}