namespace Biblioteca
{
    public abstract class Documents
    {
        private int _id; 
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        private string? _title;

        public string? Title
        {
            get => _title;
            set => _title = value;
        }
        private int _year;
        private int _sector;
        private bool _disponibile;

        public Documents(int id, string? title, int year, int sector, bool disponibile)
        {
            _id = id;
            _title = title;
            _year = year;
            _sector = sector;
            _disponibile = disponibile;
        }
        
        public override string ToString()
        {
            return $"id : {Id}, Title : {Title}, Year : {_year}, Sector : {_sector}, Available? : {_disponibile}";
        }
    }
}