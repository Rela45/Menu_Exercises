using System.Security.Cryptography.X509Certificates;
using EsercizioModShop;

public static class MainModShop
{
    public static void Run()
    {
        ArmaAstratta rifle = FactoryArma.MakeArma();
        Console.WriteLine("Arma base creata:");
        Console.WriteLine(rifle.ToString());
        bool continua = true;
        double prezzoStickers = 2.50;   
        double sumTotal = prezzoStickers; 
        AppContext.Instance.SetPrezzo(prezzoStickers);
        while (continua)
        {
            Console.WriteLine($"==== MENU DI SCELTE === \n1 Aggiungi sticker \n2 Stamp dell'arma attuale \n3 Esci dal programma");
            string? scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Console.WriteLine($"Aggiungi il nome dello sticker");
                    string? nomeSticker = Console.ReadLine();
                    sumTotal += prezzoStickers;
                    AppContext.Instance.SetPrezzo(sumTotal);
                    rifle = new StickerDecorator(rifle, nomeSticker);
                    Console.WriteLine($"Sticker {nomeSticker} aggiunto all'arma");
                    break;
                case "2":
                    Console.WriteLine($"\n Arma attuale :" + rifle.ToString());
                    break;
                case "3":
                    continua = false;
                    break;
                default: 
                    Console.WriteLine($"scelta non valida, riprova");
                    break;
            }
        }
        

    }
}