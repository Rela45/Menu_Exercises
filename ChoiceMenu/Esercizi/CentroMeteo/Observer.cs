public interface IObserver{
    void Aggiorna(string messaggio);
}

public interface ISoggetto{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

public class CentroMeteo : ISoggetto{
    private List<IObserver> _osservatoreList = new List<IObserver>();
    private string dati;

    
    public void AggionaMeteo(string dati){
        Console.WriteLine("Meteo Aggiornato");
        Notifica(dati);
    }

    public void Notifica(string dati)
    {
        foreach (var observer in _osservatoreList)
        {
            observer.Aggiorna(dati);
        }
    }

    public void Registra(IObserver osservatore)
    {
        _osservatoreList.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        _osservatoreList.Remove(osservatore);
    }
}

public class DisplayConsole : IObserver
{
    private string _nome;
    private string? nuovoMessaggio;
    public DisplayConsole(string nome)
    {
        _nome = nome;
    }

    public void Aggiorna(string messaggio)
    {
        nuovoMessaggio = messaggio;
        Console.WriteLine($"{_nome} ha ricevuto aggiornamenti meteo {nuovoMessaggio}");
    }


}

public class DisplayMobile : IObserver
{
    private string _nome;
    private string? nuovoMessaggio;
    public DisplayMobile(string nome)
    {
        _nome = nome;
    }

    public void Aggiorna(string messaggio)
    {
        nuovoMessaggio = messaggio;
        Console.WriteLine($"{_nome} ha ricevuto aggiornamenti meteo {nuovoMessaggio}");
    }

}
