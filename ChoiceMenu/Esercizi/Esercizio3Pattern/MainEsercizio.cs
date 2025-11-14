using System.Security.Cryptography.X509Certificates;

internal class MainEsThreePattern
{
    public static void Run()
    {
        bool continua = true;
        var subj = new GestoreCreazioneUtente();
        while (continua)
        {
            Console.WriteLine("\n--- MENU  ---");
            Console.WriteLine($"1) Aggiungi Moduli");
            Console.WriteLine($"2) esci");
            

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var Log = new ModuloLog();
                    var Marketing = new ModuloMarketing();

                    subj.Registra(Log);
                    subj.Registra(Marketing);
                    Console.WriteLine($"Inserisci il nomeUtente");
                    string? nomeUser = Console.ReadLine();

                    Log.NotificaCreazione(nomeUser);
                    Marketing.NotificaCreazione(nomeUser);
                    break;
                case "2":
                    continua = false;
                    break;

            }
            
            
        }
    }
}