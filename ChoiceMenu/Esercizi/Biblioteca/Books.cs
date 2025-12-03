namespace Biblioteca
{
    public class Books : Documents
    {
        private int _nPages;

        public Books(int id, string? title, int year, int sector, bool disponibile, int pages) : base(id, title, year, sector, disponibile)
        {
            _nPages = pages;
        }

        public override string ToString()
        {
            return base.ToString() + $"Number of Pages {_nPages}";
        }
    }
}