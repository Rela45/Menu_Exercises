namespace Logger
{
    internal static class LoggerMain
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Utente utente1 = new Utente("Alice");
            Utente utente2 = new Utente("Michele");

            var log1 = Logger.GetIstanza();
            log1.ScriviMessaggio("Ciao sto avviando l'app");

            EseguiOperazioneDiBusiness();

            var log2 = Logger.GetIstanza();
            bool stessaIstanza = Object.ReferenceEquals(log1, log2);
            Console.WriteLine();
            Console.WriteLine($"Stessa istanza? {stessaIstanza}");
            Console.WriteLine($"HashCode log1: {log1.GetHashCode()} | HashCode log2: {log2.GetHashCode()}");

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();

            

        }
        static void EseguiOperazioneDiBusiness()
        {
            var logger = Logger.GetIstanza(); // ottengo (la stessa) istanza
            logger.ScriviMessaggio("Eseguo operazione di business...");
            // ... qui eventuale logica
            logger.ScriviMessaggio("Operazione completata con successo.");
        }



    }
}