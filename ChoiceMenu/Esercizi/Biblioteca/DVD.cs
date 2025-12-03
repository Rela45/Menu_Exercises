namespace Biblioteca
{
    public class DVD : Documents
    {
        private double _dvdLenght;
        public DVD(string? id, string? title, int year, int sector, bool disponibile, double dvdLenght) : base(id, title, year, sector, disponibile)
        {
            _dvdLenght = dvdLenght;
        }
    }
}