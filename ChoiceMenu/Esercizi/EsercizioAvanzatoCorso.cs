using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Corso
{
    protected string? NomeCorso;
    protected int durataOre;
    string? Docente;
    List<string> Studenti;

    public Corso(string? nomeCorso, int durataOre, string? docente)
    {
        NomeCorso = nomeCorso;
        this.durataOre = durataOre;
        Docente = docente;
        Studenti = new List<string>();
    }

    public void AggiungiStudente(string studente)
    {
        Studenti.Add(studente);
    }
    public virtual string? ToString()
    {
        return $"Corso: {NomeCorso}, Durata: {durataOre} ore, Docente: {Docente}, Studenti: {Studenti}";
    }
    
    public virtual void MetodoSpeciale(){}
}

public class CorsoMusica : Corso
{
    string? strumentoMusicale;
    public CorsoMusica(string? NomeCorso, int durataOre, string? docente, string? strumentoMusicale) : base(NomeCorso, durataOre, docente) //costruttore padre overridato in figlio e modificato aggiungendo l'attributo della classe figlio
    {
        this.strumentoMusicale = strumentoMusicale;
    }
    public override string? ToString()
    {
        return base.ToString() + $", Strumento Musicale: {strumentoMusicale}";
    }
    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica dello strumento : {strumentoMusicale}");
    }
    

}

public class CorsoPittura : Corso
{
    string? tecnica;
    public CorsoPittura(string? NomeCorso, int durataOre, string? docente, string? tecnica) : base(NomeCorso, durataOre, docente) 
    {
        this.tecnica = tecnica;
    }

    public override string? ToString()
    {
        return base.ToString() + $", Tecnica: {tecnica}";
    }
    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica della tecnica : {tecnica}");
    }
    
}

public class CorsoDanza : Corso
{
    string? stile;

    public CorsoDanza(string? NomeCorso, int durataOre, string? docente, string? stile) : base(NomeCorso, durataOre, docente)
    {
        this.stile = stile;
    }
    public override string? ToString()
    {
        return base.ToString() + $", Stile: {stile}";
    }
    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica dello stile : {stile}");
    }

}


public class EsercizioAvanzatoCorsoMain
{
    public static void Run()
    {
        List<Corso> listaCorsi = new List<Corso>();
        bool continua = true;
        //inizio menu
        while (continua)
        {
            Console.WriteLine($"inserisci il tipo di corso da inserire: 1 per Musica, 2 per Pittura, 3 per Danza, 4 per visualizzare tutti i corsi");
            int tipoCorso = int.Parse(Console.ReadLine());

            switch (tipoCorso)
            {
                case 1:
                    Console.WriteLine("Inserisci il nome del corso di Musica:");
                    string? nomeCorso = Console.ReadLine();
                    Console.WriteLine("Inserisci la durata in ore:");
                    int durataOre = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il nome del docente:");
                    string? docente = Console.ReadLine();
                    Console.WriteLine($"Inserisci lo strumento musicale");
                    string? strumentoMusicale = Console.ReadLine();
                    CorsoMusica corsoMusica = new CorsoMusica(nomeCorso, durataOre, docente, strumentoMusicale);
                    Console.WriteLine($"Inserisci il nome dello studente :");
                    string? studente = Console.ReadLine();
                    corsoMusica.AggiungiStudente(studente);    
                    listaCorsi.Add(corsoMusica);
                    break;
                case 2: 
                    Console.WriteLine("Inserisci il nome del corso di Pittura:");
                    string? nomeCorso2 = Console.ReadLine();
                    Console.WriteLine("Inserisci la durata in ore:");
                    int durataOre2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il nome del docente:");
                    string? docente2 = Console.ReadLine();
                    Console.WriteLine($"Inserisci la tecnica da utilizzare");
                    string? tecnica = Console.ReadLine(); 
                    CorsoMusica corsoPittura = new CorsoMusica(nomeCorso2, durataOre2, docente2, tecnica);
                    Console.WriteLine($"Inserisci il nome dello studente :");
                    string? studente2 = Console.ReadLine();
                    corsoPittura.AggiungiStudente(studente2);
                    listaCorsi.Add(corsoPittura);
                    break;
                case 3:
                    Console.WriteLine("Inserisci il nome del corso di Danza:");
                    string? nomeCorso3 = Console.ReadLine();
                    Console.WriteLine("Inserisci la durata in ore:");
                    int durataOre3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il nome del docente:");
                    string? docente3 = Console.ReadLine();
                    
                    Console.WriteLine($"Inserisci lo stile da utilizzare ");
                    string? stile = Console.ReadLine();
                    
                    CorsoMusica corsoDanza = new CorsoMusica(nomeCorso3, durataOre3, docente3, stile);
                    Console.WriteLine($"Inserisci il nome dello studente :");
                    string? studente3 = Console.ReadLine();
                    corsoDanza.AggiungiStudente(studente3);

                    listaCorsi.Add(corsoDanza);

                    break;
                    //il procedimento dovrebbe essere uguale per tutti e 3 i casi di tipoCorso
                case 4:
                    foreach(var c in listaCorsi)
                    {
                        Console.WriteLine(c);
                    }
                    break;
                    
                    // -----------questa poteva essere una soluzione usato insieme alla lista creata nel main o si doveva gestire in modo completamente diverso come avevo immaginato usando solo la lista in Corso?--------------------
                    // foreach (var studente in studentiMusica)
                    // {
                    //     corsoMusica.AggiungiStudente(studente);
                    // }


                    //-------------------------------------------Devo verificare che questo tipo di codice vada bene che in consegna non ho capito bene cosa si intendeva---------------------------
                    // List<string> studenti = new List<string>();
                    // for (int i = 0; i < numStudenti; i++)
                    // {
                    //     Console.WriteLine($"Inserisci il nome dello studente {i + 1}:");
                    //     studenti.Add(Console.ReadLine());
                    // }
                    // Console.WriteLine("Inserisci lo strumento musicale:");
                    // string? strumentoMusicale = Console.ReadLine();
                    // listaCorsi.Add(new CorsoMusica(nomeCorso, durataOre, docente, studenti, strumentoMusicale));
                    // break;
                    // case 2:
                    // Console.WriteLine("Inserisci il nome del corso di Pittura:");
                    // string? nomeCorsoPittura = Console.ReadLine();
                    // Console.WriteLine("Inserisci la durata in ore:");
                    // int durataOrePittura = int.Parse(Console.ReadLine());
                    // Console.WriteLine("Inserisci il nome del docente:");
                    // string? docentePittura = Console.ReadLine();
                    // Console.WriteLine("Inserisci il numero di studenti:");
                    // int numStudentiPittura = int.Parse(Console.ReadLine());
                    // List<string> studentiPittura = new List<string>();
                    // for (int i = 0; i < numStudentiPittura; i++)
                    // {
                    //     Console.WriteLine($"Inserisci il nome dello studente {i + 1}:");
                    //     studentiPittura.Add(Console.ReadLine());
                    // }
                    // Console.WriteLine("Inserisci la tecnica:");
                    // string? tecnica = Console.ReadLine();
                    // listaCorsi.Add(new CorsoPittura(nomeCorsoPittura, durataOrePittura, docentePittura, studentiPittura, tecnica));
                    // break;






                    break;
            }
            
            //in compilazione funzionava il metodo e riuscivo a salvare i nomi degli studenti
        }
    }
}