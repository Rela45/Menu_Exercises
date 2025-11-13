using System.Runtime.CompilerServices;

public class VeicoloFactory
{
    private static VeicoloFactory _instance;

    public static VeicoloFactory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new VeicoloFactory();
            return _instance;
        }
    }

    private VeicoloFactory()
    {
        Console.WriteLine($"impedisco la creazione dall'esterno");
    }

    public static IVeicolo CreaVeicolo(string type)
    {
        switch (type.ToLower())
        {
            case "auto":
                return new ConcreteAuto();
            case "moto":
                return new ConcreteMoto();
            case "camion":
                return new ConcreteCamion();
            default:
                return null;
        }
    }
}