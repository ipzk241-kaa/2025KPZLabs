namespace Singleton
{
    class Authenticator
    {
        private static readonly object _lock = new object();
        private static Authenticator _instance;

        private Authenticator() { }

        public static Authenticator GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Authenticator();
                }
            }
            return _instance;
        }
    }
}
