using AppConfig;
using Logger;
using MiniAppPagamenti;
internal class Program
{
    static void Main()
    {
        bool exit = false;

        Dictionary<int, (string Nome, Action Metodo)> esercizi = new()
            {
                { 1, ("Esercizio Operator ambulanza", OperatoreMain.Run) },
                { 2, ("Esercizio StrategyCalcolatrice", CalcolatriceMain.Run) },
                { 3, ("Esercizio MiniAppPagamenti con enum", PagamentiMain.Run) },
                { 4, ("Esercizio Singleton Logger", LoggerMain.Run) },
                { 5, ("Esercizio OrderHub", AppconfigMain.Run) },
                { 6, ("Esercizio GreetingService", GreetingServiceMain.Run) },
                { 7, ("Esercizio PaymentService", PaymentProcessMain.Run) },
                { 8, ("Esercizio ConfigurazioneSistemaDualPattern", RunClass.Run) },
                { 9, ("Esercizio Veicolo con Factory (da correggere)", VeicoloConFactoryMethodMain.Run) },
                { 10,("Esercizio Save on Disk or Cache (hardcoded)", MainSaver.Run) },
                { 11,("Esercizio Livello Accesso con enums (da correggere output)", MainLivelloAccesso.Run) },
                { 12,("Esercizio Notifier con enums", MainNotifier.Run) },
                { 13,("Esercizio Prenotazioni con ereditarieta e tostring override (da correggere, esercizio vecchio)", MainPrenotazioniEreditarieta.Run) },
                { 14,("Esercizio Observer notifiche meteo", MainObserverMeteo.Run) },
                { 15,("Esercizio NewsAgency con Singleton", MainNewsAgency.Run) },
            };

        

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===  MENU ESERCIZI ===");
            foreach (var kvp in esercizi)
                Console.WriteLine($"{kvp.Key}. {kvp.Value.Nome}");

            Console.WriteLine("0. Esci");
            Console.Write("\nSeleziona un esercizio: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int scelta))
            {
                if (scelta == 0)
                {
                    exit = true;
                }
                else if (esercizi.ContainsKey(scelta))
                {
                    Console.Clear();
                    Console.WriteLine($" Esecuzione esercizio {scelta}...\n");
                    esercizi[scelta].Metodo.Invoke();

                    Console.WriteLine("\nPremi un tasto per tornare al menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(" Esercizio non valido!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(" Inserisci un numero valido!");
                Console.ReadKey();
            }
        }
    }
}