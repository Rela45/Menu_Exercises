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
                { 4, ("Esercizio OrderHub", AppconfigMain.Run) },
            };

        

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== 📚 MENU ESERCIZI ===");
            foreach (var kvp in esercizi)
                Console.WriteLine($"{kvp.Key}. {kvp.Value.Nome}");

            Console.WriteLine("0. ❌ Esci");
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
                    Console.WriteLine($"▶ Esecuzione esercizio {scelta}...\n");
                    esercizi[scelta].Metodo.Invoke();

                    Console.WriteLine("\nPremi un tasto per tornare al menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("❗ Esercizio non valido!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("❗ Inserisci un numero valido!");
                Console.ReadKey();
            }
        }
    }
}