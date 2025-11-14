using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public sealed class UserFactory
{
    private static UserFactory _instance;

    private UserFactory() { }

    public static UserFactory Istanza
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserFactory();
            }
            return _instance;
        }
    }

    public Utente Crea(string nome)
    {
        return new Utente(nome);
    }

}

public class Utente
{
    public string nome;

    public Utente(string nome)
    {
        this.nome = nome;
    }

    public override string ToString()
    {
        return $"Nome : {nome}";
    }
}