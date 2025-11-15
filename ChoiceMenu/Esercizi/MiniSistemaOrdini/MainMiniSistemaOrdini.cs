#region MAIN
using System.Runtime.InteropServices;
using Domain;
using Infrastructure;
using LayerApplication;

internal static class MainSistemaOrdini
{
    public static void Run()
    {
        var config = Configurazione.Instance;

        var prodotti = new List<Product>();
        // var prodotti = new ProductService();           //stavo provando cose, mi sono accorto di aver semplificato il main come nell'esercizio easy guidato e non ho usato application e infrastructure 
        var ordini = new List<Order>();
        // var ordini = new OrderService()
        prodotti.Add(new Product("PEN", "Penna Blu", 1.50m));
        prodotti.Add(new Product("NBK", "Taccuino", 4.20m));
        prodotti.Add(new Product("MUG", "Tazza Logo", 8.90m));

        Console.WriteLine($"==== PRODOTTI DISPONIBILI ===");
        foreach (var p in prodotti)
        {
            Console.WriteLine($"{p.Code} - {p.Name} - {p.Price:0.00} {config.Currency}");
        }

        bool continua = true;
        Console.WriteLine($"Inserisci il tuo nome per cominciare l'ordine");
        string? nome = Console.ReadLine();
        var ordine = new Order(nome);
        ordini.Add(ordine);
        Console.WriteLine($"\nOrdine creato (ID: {ordine.Id}) per {ordine.Customer}");
        int counts = 0;
        while (continua)
        {
            Console.WriteLine($"-------MENU------- \n 1.Aggiungi prodotto \n 2. Calcola il totale \n 3. Conferma pagamento \n 0. esci");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bool fine = true;
                    while (fine)
                    {
                        Console.WriteLine($"Inserisci il codice del prodotto");
                        string? codice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(codice)) break;

                        var prodotto = prodotti.FirstOrDefault(p => p.Code.Equals(codice, StringComparison.OrdinalIgnoreCase));
                        if (prodotto == null)
                        {
                            Console.WriteLine($"Prodotto non trovato");
                            continue;
                        }
                        Console.WriteLine($"Quantita'");
                        int qty = Convert.ToInt32(Console.ReadLine());
                        if (qty <= 0)
                        {
                            Console.WriteLine($"la mole di prodotti deve essere maggiore di 0");
                            continue;
                        }
                        ordine.AddItems(prodotto, qty);
                        counts++;
                        Console.WriteLine($"Prodotti aggiunti.");
                        Console.WriteLine($"Vuoi continuare? s/n");
                        string scelta = Console.ReadLine();
                        if (scelta.Contains("s"))
                        {
                            continue;
                        }
                        else
                        {
                            fine = false;
                        }
                        
                    }
                    break;
                case "2":
                    var sub = ordine.SubTotal();
                    var iva = Math.Round(sub * config.TaxRate, 2);
                    var totale = sub + iva;
                    Console.WriteLine($"{totale}");
                    break;
                case "3":
                    ordine.Pay();
                    Console.WriteLine($"Ordine pagato. Stato attuale: {ordine.Status}");
                    Console.Write("Vuoi spedire l’ordine (s/n)? ");
                    if (Console.ReadLine()?.Trim().ToLower() == "s")
                    {
                        ordine.Ship();
                        Console.WriteLine($"Ordine spedito. Stato attuale: {ordine.Status}");
                    }
                    break;
                case "0":
                    continua = false;
                    break;
            }
        }
        Console.WriteLine("\n=== RIEPILOGO ORDINI ===");
        foreach (var o in ordini)
        {
            Console.WriteLine($"Ordine {o.Id} | Cliente: {o.Customer} | Stato: {o.Status} | Totale articoli: {counts}");
        }
    }
}

#endregion