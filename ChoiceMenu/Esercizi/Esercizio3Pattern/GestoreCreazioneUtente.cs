using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class GestoreCreazioneUtente : ISoggetto
{

    private List<IObserver> _observers = new List<IObserver>();
    private string _nome;

    void CreaUtente(string _nome)
    {
        
    }
    
    public void Notifica()
    {
        foreach(var o in _observers)
        {
            o.NotificaCreazione(_nome);
        }
    }

    public void Registra(IObserver o)
    {
        _observers.Add(o);
    }

    public void Rimuovi(IObserver o)
    {
        _observers.Remove(o);
    }
}
