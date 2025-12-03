namespace Biblioteca
{
    public abstract class Documents
    {
        private string? _id;
        private string? _title;
        private int _year;
        private int _sector;
        private bool _disponibile;

        public Documents(string? id, string? title, int year, int sector, bool disponibile)
        {
            _id = id;
            _title = title;
            _year = year;
            _sector = sector;
            _disponibile = disponibile;
        }
    }
}