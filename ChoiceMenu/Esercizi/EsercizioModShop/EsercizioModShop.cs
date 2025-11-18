namespace EsercizioModShop
{
    #region Factory
    public static class FactoryArma
    {
        public static List<ArmaAstratta> armi = new List<ArmaAstratta>();

        public static ArmaAstratta MakeArma()
        {
            ArmaAstratta rifle = new Rifle("DragonBreath");
            armi.Add(rifle);
            return rifle;
        }
    }
    #endregion
}
