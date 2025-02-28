using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class AddNewItem 
    {
        public static Product CreateProduct()
        {
            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();

            Console.Write("Введіть категорію товару: ");
            string category = Console.ReadLine();

            Console.Write("Введіть одиницю виміру: ");
            string unit = Console.ReadLine();

            Console.Write("Введіть ціну товару: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
            {
                Console.WriteLine("Некоректне значення ціни. Використано значення за замовчуванням 0.");
                price = 0;
            }

            Console.Write("Введіть кількість: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Некоректне значення кількості. Використано значення за замовчуванням 0.");
                quantity = 0;
            }

            return new Product(name, category, unit, price, quantity, DateTime.Now);
        }
    }
}