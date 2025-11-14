using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class ModuloLog : IObserver
    {
        public void NotificaCreazione(string nomeUtente)
        {
            Console.WriteLine($"Utente : {nomeUtente} creato"); 
        }
    }
