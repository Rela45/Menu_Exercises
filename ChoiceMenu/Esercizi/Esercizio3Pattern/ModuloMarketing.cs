using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Benvenuto nuovo utente : {nomeUtente} "); 
    }
}
