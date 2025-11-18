using System.ComponentModel;

public sealed class AppContext
{
    private static readonly Lazy<AppContext> _lazy = new(()=> new AppContext());
    public static AppContext Instance => _lazy.Value;

    public double prezzo{ get;  set; }

    public void SetPrezzo(double nuovoPrezzo)
    {
        prezzo = nuovoPrezzo;
    }

}