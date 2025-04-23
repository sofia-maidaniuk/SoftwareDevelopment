using System;
using System.Text;
using LibraryChainOfResponsibility;

namespace ConsoleApp_SupportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Вітаємо у системі підтримки користувачів!");
                var handlers = SupportHandlerFactory.CreateDefaultHandlers();

                // Ланцюжок відповідальностей
                for (int i = 0; i < handlers.Count - 1; i++)
                {
                    handlers[i].SetNextHandler(handlers[i + 1]);
                }

                var current = handlers[0];

                while (true)
                {
                    current.HandleRequest(0); // 0 — умовний рівень, якщо не використовується
                    if (current.RequestHandled)
                        break;

                    current = current.GetNextHandler();
                    if (current == null)
                    {
                        Console.WriteLine("Жоден рівень не підійшов. Почнімо спочатку.\n");
                        break;
                    }
                }

                Console.Write("\nБажаєте ще раз скористатись системою? (y/n): ");
                var again = Console.ReadLine()?.ToLower();
                if (again != "y")
                {
                    Console.WriteLine("Дякуємо за звернення! Гарного дня!");
                    break;
                }

                Console.Clear();
            }
        }
    }
}
