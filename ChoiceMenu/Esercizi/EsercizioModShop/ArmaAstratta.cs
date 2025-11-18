public abstract class ArmaAstratta
{
    public string skin;
    public double price;

    public ArmaAstratta(string skin = "default") //se segno un parametro di default nel costruttore questo non ha bisogno di essere dichiarato altrove
    {
        this.skin = skin;
    }
    public override string ToString()
    {
        return skin;
    }
}