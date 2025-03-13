using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SingletonLibrary;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Імітація доступу до Singleton з різних потоків
            Thread thread1 = new Thread(() =>
            {
                Authenticator auth1 = Authenticator.GetInstance();
                Console.WriteLine("Thread 1: Trying to authenticate admin/password...");
                Console.WriteLine($"Authentication result: {auth1.Authenticate("admin", "password")}");
            });

            Thread thread2 = new Thread(() =>
            {
                Authenticator auth2 = Authenticator.GetInstance();
                Console.WriteLine("Thread 2: Trying to authenticate user/12345...");
                Console.WriteLine($"Authentication result: {auth2.Authenticate("user", "12345")}");
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // Додаткове підтвердження, що екземпляри однакові
            Authenticator instance1 = Authenticator.GetInstance();
            Authenticator instance2 = Authenticator.GetInstance();
            Console.WriteLine($"Are both instances the same? {ReferenceEquals(instance1, instance2)}");
        }
    }
}
