
#region Interface
public interface Security
{
    void SecurityAccess(LivelloAccesso accesso);
}

#endregion
public enum LivelloAccesso
{
    Rookie,
    Midlevel,
    Pro
}
#region LivelloAccesso
public class Access : Security
{
    public void SecurityAccess(LivelloAccesso accesso)
    {
        switch (accesso)
        {
            case LivelloAccesso.Rookie:
                Console.WriteLine($"Il tuo livello è Rookie i tuoi sono privilegi minimi");
                break;
            case LivelloAccesso.Midlevel:
                Console.WriteLine($"Il tuo livello è Mid puoi accedere a privilegi di alto livello");
                break;
            case LivelloAccesso.Pro:
                Console.WriteLine($"Il tuo livello è Pro hai accesso completo");
                break;
        }
    }
}
#endregion



#region MAIN 

class MainLivelloAccesso
{
    public static void Run()
    {
        var accesso = new Access();
        Console.WriteLine($"inserisci Il tuo livello (Rookie, Mid, Pro)");
        
        string input = Console.ReadLine();
        switch (input)
        {
            case "Rookie":
                accesso.SecurityAccess(LivelloAccesso.Rookie);
                break;
            case "Mid":
                accesso.SecurityAccess(LivelloAccesso.Midlevel);
                break;
            case "Pro":
                accesso.SecurityAccess(LivelloAccesso.Pro);
                break;
        }
    }
}

#endregion