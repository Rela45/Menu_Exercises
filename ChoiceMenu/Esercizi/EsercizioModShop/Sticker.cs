public class StickerDecorator : ArmaAstratta
{
    private ArmaAstratta armaComponent;
    private string _sticker;
    private double _stickerPrice = 2.5;
    public StickerDecorator(ArmaAstratta armaComponent, string stiker)
    {
        this.armaComponent = armaComponent;
        _sticker = stiker;
        _stickerPrice = AppContext.Instance.prezzo;
    }
    public override string ToString()
    {
        return armaComponent.ToString() +" " + _sticker + " " + _stickerPrice;
    }
}
