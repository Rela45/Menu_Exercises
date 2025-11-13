class Operatore    //padre
{
    private string? _name;
    private string? _turno;

    public Operatore(string? name, string? turno)
    {
        _name = name;
        _turno = turno;
    }

    public string? Name { get; set; }
    public string? Turno
    {
    get { return Turno; }
    set
    {
        if (value == "giorno" || value == "notte")
        {
            Turno = value;
        }
        else
        {
            Console.WriteLine("Error 122: Wrong value");
        }
    }
    }

    public override string ToString()
    {
        return $"Nome: {_name} Turno: {_turno} ";
    }


    public virtual void EseguiCompito()
    {
        Console.WriteLine($"Operatore generico in servizio");

    }


}

class OperatoreEmergenza : Operatore   //figlio 1
{
    public int livelloUrgenza;
    public OperatoreEmergenza(string? name, string? turno, int livelloUrgenza) : base(name, turno)
    {
        this.livelloUrgenza = livelloUrgenza;
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Gestione emergenza di livello {livelloUrgenza}");

    }



}

class OperatoreSicurezza : Operatore  //figlio 2
{
    public string? areaSorvegliata;
    public OperatoreSicurezza(string? name, string? turno, string? areaSorvegliata) : base(name, turno)
    {
        this.areaSorvegliata = areaSorvegliata;
    }


    public override void EseguiCompito()
    {
        /// <summary>
        /// stampa una stringa in console (sicurezza)
        /// </summary>
        /// <value>richiede una stringa</value>
        Console.WriteLine($"Sorveglianza dell'area {areaSorvegliata}");
    }

}

class OperatoreLogistica : Operatore   //figlio 3
{
    public int numeroConsegne;

    public OperatoreLogistica(string? name, string? turno, int numeroConsegne) : base(name, turno)
    {
        this.numeroConsegne = numeroConsegne;
    }

    public override void EseguiCompito()
    {
        /// <summary>
        /// stampa una stringa in console (logistica)
        /// </summary>
        /// <value>richiede un valore (int)</value>
        Console.WriteLine($"Coordinamento di {numeroConsegne} consegne");
    }
}

public static class OperatoreMain
{
    public static void Run()
    {
        var lista = new List<Operatore>();
        bool esci = false;
        //comincio il menu ora
        while (!esci)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1) Aggiungi Operatore Emergenza");
            Console.WriteLine("2) Aggiungi Operatore Sicurezza");
            Console.WriteLine("3) Aggiungi Operatore Logistica");
            Console.WriteLine("4) Stampa tutti (tipo, nome, turno)");
            Console.WriteLine("5) Chiama EseguiCompito() su tutti");
            Console.WriteLine("6) Esci");
            Console.Write("Scelta: ");

            switch (Console.ReadLine())
            {
                case "1": AggiungiEmergenza(lista); break;
                case "2": AggiungiSicurezza(lista); break;
                case "3": AggiungiLogistica(lista); break;
                case "4": Stampa(lista); break;
                case "5": EseguiTutti(lista); break;
                case "6": esci = true; break;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
        //--------------------------Input Rapidi---------------------------------

        static string LeggiStringa(string prompt, string def = "")    //prendo input dall'utente
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? def : s.Trim();
        }

        static int LeggiIntero(string prompt, int min, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int n) && n >= min && n <= max)
                    return n;
                Console.WriteLine("Valore non valido, riprova.");
            }
        }


        //---------------------------Azioni Menu----------------------------------


        void AggiungiEmergenza(List<Operatore> lista)
        {
            string nome = LeggiStringa("Nome:");
            string turno = LeggiStringa("Turno (giorno)", "giorno");
            int livello = LeggiIntero("Livello urgenza (1-5)", 1, 5);
            lista.Add(new OperatoreEmergenza(nome, turno, livello));
            Console.WriteLine($"OperatoreEmergenza Aggiunto");
        }

        void AggiungiSicurezza(List<Operatore> lista)
        {
            string nome = LeggiStringa("Nome: ");
            string turno = LeggiStringa("Turno (giorno/notte): ", "giorno");
            string area = LeggiStringa("Area sorvegliata: ", "N/D");
            lista.Add(new OperatoreSicurezza(nome, turno, area));
            Console.WriteLine("Operatore Sicurezza aggiunto.");
        }

        void AggiungiLogistica(List<Operatore> lista)
        {
            string nome = LeggiStringa("Nome: ");
            string turno = LeggiStringa("Turno (giorno/notte): ", "giorno");
            int consegne = LeggiIntero("Numero consegne (>=0): ", 0);
            lista.Add(new OperatoreLogistica(nome, turno, consegne));
            Console.WriteLine("Operatore Logistica aggiunto.");
        }

        void Stampa(List<Operatore> lista)
        {
            if (lista.Count == 0) { Console.WriteLine("Nessun operatore."); return; }
            Console.WriteLine("\n--- OPERATORI ---");
            foreach (var op in lista) Console.WriteLine(op);
        }

        void EseguiTutti(List<Operatore> lista)
        {
            if (lista.Count == 0) { Console.WriteLine("Nessun operatore."); return; }
            Console.WriteLine("\n--- ESEGUI COMPITO (polimorfismo) ---");
            foreach (var op in lista) op.EseguiCompito();
        }
    }
}