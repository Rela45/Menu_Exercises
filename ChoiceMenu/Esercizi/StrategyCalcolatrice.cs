#region INTERFACE
public interface IStrategiaOperazione
{
    double Calcola(double a, double b);
}
#endregion
#region ConcreteStrategy
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}



public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}

public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}

public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (a == 0)
        {
            Console.WriteLine($"Il primo dividendo non può essere 0");
        }
        return a / b;
    }
}

#endregion

#region Context
public class Calcolatrice
{
    private IStrategiaOperazione _strategiaOperazione;



    public void ImpostaStrategia(IStrategiaOperazione strategiaOperazione)
    {

        _strategiaOperazione = strategiaOperazione;
    }
    
    public void EseguiOperazione(double a, double b)
    {
        if (_strategiaOperazione == null)
        {
            Console.WriteLine($"Nessuna operazione scelta");
            return;
        }
        double result = _strategiaOperazione.Calcola(a, b);
        Console.WriteLine($"Risultato dell'operazione : {result}");
        
    }
}


#endregion
#region Utente
public sealed class User
{
    private static User? istanza;
    private List<double> risultati = new List<double>();
    private User() { }
    public static User GetIstanza()
    {
        if (istanza == null)
        {
            istanza = new User();
        }
        return istanza;
    }

    public void AggiungiRisultato(double risultato)
    {
        risultati.Add(risultato);
    }

    public void StampaRisultati()
    {
        foreach (var risultato in risultati)
        {
            Console.WriteLine(risultato);
        }
    }
}

#endregion

#region MAIN
public static class CalcolatriceMain
{
    public static void Run()
    {
        Console.WriteLine($"Inserisci 2 numeri");
        Utils.ReadLine(out double a);
        Utils.ReadLine(out double b);

        var context = new Calcolatrice();

        Console.WriteLine($"Scegli l'operazione (addizione, sottrazione, moltiplicazione, divisione)");
        Utils.ReadLine(out string operazione);

        switch (operazione)
        {
            case "addizione":
                context.ImpostaStrategia(new SommaStrategia());
                context.EseguiOperazione(a, b);
                break;

            case "sottrazione":
                context.ImpostaStrategia(new SottrazioneStrategia());
                context.EseguiOperazione(a, b);
                break;
            case "moltiplicazione":
                context.ImpostaStrategia(new MoltiplicazioneStrategia());
                context.EseguiOperazione(a, b);
                break;

            case "divisione":
                context.ImpostaStrategia(new DivisioneStrategia());
                context.EseguiOperazione(a, b);
                break;
            default:
                Console.WriteLine($"Operazione scelta non supportata");
                break;
        }
    }
}

#endregion.