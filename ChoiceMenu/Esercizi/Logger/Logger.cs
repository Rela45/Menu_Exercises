using System;
namespace Logger
{
    public sealed class Logger
    {
        private static Logger _istanza;

        private static readonly object _lock = new object();

        private Logger() { }

        public static Logger GetIstanza()
        {
            if (_istanza is null)
            {
                lock (_lock)
                {
                    if (_istanza is null)
                    {
                        _istanza = new Logger();
                    }
                }
            }
            return _istanza;
        }
        
        public void ScriviMessaggio(string messaggio)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{timestamp}]{messaggio}");
        }
    }
}