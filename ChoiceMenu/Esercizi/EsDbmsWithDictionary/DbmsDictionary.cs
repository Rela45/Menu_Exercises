
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
namespace EsDbmsWithDictionary{
#region User
public interface IUser
{
    string NotificaCreazione();
}

public class User : IUser
{
    public int Id { get; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public User(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }



    public override string ToString()
    {
        return $"ID: {Id}, Nome: {Nome}, Email: {Email}";
    }

    public string NotificaCreazione()
    {
        return "utente" + Nome + "creato con successo";
    }
}
#endregion

#region Users
public sealed class Users
{
    private static readonly Users _instance = new Users();
    public static Users Instance => _instance;
    private static Dictionary<int, User> _users = new Dictionary<int, User>();


    private Users() { }

    public void Add(User user)
    {
        if (!_users.ContainsKey(user.Id))
        {
            Console.WriteLine($"User added to the list");
            
            _users.Add(user.Id, user);
        }
        else
        {
            Console.WriteLine($"Existing user");

        }
    }

    public void Remove(User user)
    {
        if (_users.ContainsKey(user.Id))
        {
            _users.Remove(user.Id);
        }
        else
        {
            Console.WriteLine($"User not found");
        }
    }
    
}

#endregion

#region FactoryUser

public abstract class UserFactory
{
    public abstract User FactoryMethod(int id, string nome, string email);
}

public class ConcreteUserFactory : UserFactory
{
    public override User FactoryMethod(int id, string nome, string email)
    {
        return new User(id, nome, email);
    }
}
#endregion


#region Action Log
public interface IAction
{
    void Update(string newState);
}

public interface ISubject
{
    void Attach(IAction observer);
    void Detach(IAction observer);
    void Notify();
}



#endregion
#region Main
static class MainEsDictionaryDbms 
{
    public static void Run()
    {

        var users = Users.Instance;
        var factory = new ConcreteUserFactory();
        Console.WriteLine($"inserisci id");
        

        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Inserisci email:");
        string email = Console.ReadLine();

        var nuovoUtente = factory.FactoryMethod(id, nome, email);
        nuovoUtente.NotificaCreazione();
        users.Add(nuovoUtente);
        

    }
}
#endregion
}