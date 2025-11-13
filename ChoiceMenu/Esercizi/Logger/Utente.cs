namespace Logger
{
    public  class Utente
    {
        public string Nome { get; set; }

        public Utente(string nome)
        {
            Nome = nome;
        }
        
        public void EseguiAzione(string azione)
        {
            Logger logger = Logger.GetIstanza();
            logger.ScriviMessaggio($"{Nome} esegue {azione}");
        }
    }
}