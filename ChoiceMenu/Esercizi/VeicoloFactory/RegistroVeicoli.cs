class RegistroVeicoli
{
    private static RegistroVeicoli _instance;

    public static RegistroVeicoli Instance{get{return _instance;}}
    private List<IVeicolo> veicoliCreati;

    public void Registra(IVeicolo veicolo)
    {
        veicoliCreati.Add(veicolo);
    }

    public void StampaTutti()
    {
        foreach (var veicolo in veicoliCreati)
        {
            Console.WriteLine($"{veicolo}");
        }
    }
}