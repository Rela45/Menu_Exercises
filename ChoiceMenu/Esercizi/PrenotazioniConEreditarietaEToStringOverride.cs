using System;



class PrenotazioneViaggio
{
    private int postiPrenotati;
    private const int MAX_POSTI = 20;

    public string Destinazione { get; set; }  //setto la destinazione come proprietà
    

    public int PostiLiberi()    //calcolo i postiliberi
    {
        return MAX_POSTI - postiPrenotati;
    }


    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (PostiLiberi() >= numeroPosti)
        {
            postiPrenotati += numeroPosti;
            Console.WriteLine($"Prenotazione effettuata correttamente");

        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti disponibili");
        }
    }
    public void RimuoviPrenotazione(int numeroPosti)
    {
        if (postiPrenotati > 0)
        {
            postiPrenotati -= numeroPosti;
            Console.WriteLine($"Prenotazione annullata");
        }
        else
        {
            Console.WriteLine($"Non hai effettuato alcuna prenotazione");
        }
    }

    public int PostiPrenotati
    {
        get { return postiPrenotati; }        //mi prendo i posti prenotati per usarli in un calcolo successivamente
    }

}

class Utente : PrenotazioneViaggio
{
    private string? nome;

    public Utente(string? nome)
    {
        this.nome = nome;
    }
    public override string ToString()
    {
        return nome;
    }
}


static class MainPrenotazioniEreditarieta
{
    public static void Run()
    {
        bool continua = true;   
        PrenotazioneViaggio prenotazione = new PrenotazioneViaggio();
        List<Utente> listaUtenti = new List<Utente>();  //la uso per salvarmi gli utenti

        while (continua)
        {
            Console.WriteLine($"inserisci il tuo nome");
            string? nome = Console.ReadLine();
            listaUtenti.Add(new Utente(nome));
            Console.WriteLine($"Premi: \n1 per aggiungere una destinazione \n2 per prenotare il viaggio \n3 per annullare una prenotazione\n4 per uscire dall'applicazione");
            int scelta = Convert.ToInt32(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine($"Aggiungi una destinazione");
                    prenotazione.Destinazione = Console.ReadLine();
                    continue;

                case 2:
                    Console.WriteLine($"quanti posti vuoi prenotare?");
                    int input = Convert.ToInt32(Console.ReadLine());
                    prenotazione.EffettuaPrenotazione(input);
                    break;

                case 3:
                    Console.WriteLine($"quanti posti vuoi rimuovere?");
                    int input2 = Convert.ToInt32(Console.ReadLine());
                    prenotazione.RimuoviPrenotazione(input2);
                    break;

                case 4:
                    Console.WriteLine($"fine");
                    continua = false;
                    break;

                    
                }
            foreach (Utente utente in listaUtenti)
            {
                Console.WriteLine($"posti prenotati : {prenotazione.PostiPrenotati} , da : {utente} ");     
            }
        
        }
    }
}
