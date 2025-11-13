
    public sealed class ConfigurazioneSistema
    {
        private static ConfigurazioneSistema? _instance;

        private static readonly object _instanceLock = new object();

        private Dictionary<string, string> _keyValuePairs;

        private ConfigurazioneSistema()
        {
            _keyValuePairs = new Dictionary<string, string>();
        }

        public static ConfigurazioneSistema GetInstance()
        {
            if (_instance is null)
            {
                lock (_instanceLock)
                {
                    if (_instance is null)
                    {
                        _instance = new ConfigurazioneSistema();
                    }
                }
            }
            return _instance;
        }

        public void Imposta(string key, string value)
        {
            _keyValuePairs.Add(key, value);
        }

        public string? Leggi(string key)
        {
            if (_keyValuePairs.ContainsKey(key))
            {
                return $"la chiave dell'istanza è {_keyValuePairs[key]}";
            }
            else
            {
                return null;
            }

        }

        public void StampaTutte()
        {
            foreach (var kvp in _keyValuePairs)
            {
                Console.WriteLine($"Chiave: {kvp.Key}, Valore: {kvp.Value}");
            }
        }
    }
