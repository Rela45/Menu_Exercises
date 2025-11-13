class RunClass
{
    public static void Run()
    {

// Simulazione Modulo A
        var ModuloA = ConfigurazioneSistema.GetInstance();
        ModuloA.Imposta("volume", "80");
        
        var dispositivoA = DispositivoFactory.CreaDispositivo("computer");

        // Simulazione Modulo B
        var ModuloB = ConfigurazioneSistema.GetInstance();
        ModuloB.Imposta("lingua", "it");


        var dispositivoB = DispositivoFactory.CreaDispositivo("stampante");

        // Verifica che le due istanze siano le stesse
        Console.WriteLine(Object.ReferenceEquals(ModuloA, ModuloB));  // true

        // Stampa tutte le configurazioni
        Console.WriteLine("\nConfigurazioni:");
        ModuloA.StampaTutte();

        // Avvia dispositivi
        Console.WriteLine("\nDispositivo A:");
        dispositivoA?.Avvia();
        dispositivoA?.MostraTipo();

        Console.WriteLine("\nDispositivo B:");
        dispositivoB?.Avvia();
        dispositivoB?.MostraTipo();

    }
}