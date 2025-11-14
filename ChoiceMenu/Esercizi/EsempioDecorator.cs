#region INTERFACES
using System.Dynamic;

public interface IBevanda
{
    void Descrizione();
    double Costo();
}
#endregion
#region classi concrete
public class Caffe : IBevanda
{
    private double _costo;
    public Caffe(double costo)
    {
        _costo = costo;
    }
    public double Costo()
    {
        return _costo;
    }

    public void Descrizione()
    {
        Console.WriteLine($"Caffe corto");

    }
}

public class The : IBevanda
{
    private double _costo;
    public double Costo()
    {
        return _costo;
    }
    public void Descrizione()
    {
        Console.WriteLine($"The");

    }
}
#endregion
#region decorator
public abstract class Decorator : IBevanda
{
    protected IBevanda _bevanda;
    protected Decorator(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }
    public virtual double Costo()
    {
        return _bevanda.Costo();
    }

    public virtual void Descrizione()
    {
        _bevanda.Descrizione();
        Console.WriteLine($"Con:");
        
    }
}
#endregion
#region classi decorator
public class ConLatte : Decorator
{
    private double _costo;
    public ConLatte(IBevanda bevanda, double costo) : base(bevanda)
    {
        _costo = costo;
    }

    public override double Costo()
    {
        return base.Costo() + _costo;
    }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine(" + Latte");
    }
}

public class ConCioccolato : Decorator
{
    private double _costo;
    public ConCioccolato(IBevanda bevanda, double costo) : base(bevanda)
    {
        _costo = costo;
    }

    public override double Costo()
    {
        return base.Costo() + _costo;
    }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine(" + Cioccolato");
    }
}

public class ConPanna : Decorator
{
    private double _costo;
    public ConPanna(IBevanda bevanda, double costo) : base(bevanda)
    {
        _costo = costo;
    }

    public override double Costo()
    {
        return base.Costo() + _costo;
    }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine(" + Panna");
    }
}


#endregion


#region MAIN
internal class MainEsempioDecorator
{
    public static void Run()
    {
         // Base
        IBevanda bevanda = new Caffe(2);

        // Decorazioni
        bevanda = new ConLatte(bevanda, 0.5);
        bevanda = new ConCioccolato(bevanda, 0.7);
        bevanda = new ConPanna(bevanda, 0.6);

        // Stampa descrizione e costo
        Console.WriteLine("Descrizione:");
        bevanda.Descrizione();

        Console.WriteLine($"Costo Totale: {bevanda.Costo()}");
        
    }
}
#endregion