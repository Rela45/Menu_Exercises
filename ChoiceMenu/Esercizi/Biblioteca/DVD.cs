namespace Biblioteca
{
    public class DVD : Documents
    {
        private double _dvdLenght;
        public DVD(int id, string? title, int year, int sector, bool disponibile, double dvdLenght) : base(id, title, year, sector, disponibile)
        {
            _dvdLenght = dvdLenght;
        }
        public override string ToString()
        {
            return base.ToString() + $"Dvd Lenght : {_dvdLenght}";
        }
    }
}