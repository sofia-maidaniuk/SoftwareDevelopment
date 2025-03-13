using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLibrary
{
    public sealed class Authenticator
    {
        private static Authenticator _instance;
        private static readonly object _lock = new object();

        // Приватний конструктор забороняє створення об'єкта через new
        private Authenticator()
        {
            Console.WriteLine("Authenticator instance created.");
        }

        public static Authenticator GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Захист від одночасного доступу в багатопотоковому середовищі
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }
            return _instance;
        }

        public bool Authenticate(string username, string password)
        {
            return username == "admin" && password == "password";
        }
    }
}
