using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastRestockDate { get; set; }

        public Product(string name, string category, string unit, double price, int quantity, DateTime lastRestockDate)
        {
            Name = name;
            Category = category;
            Unit = unit;
            Price = price;
            Quantity = quantity;
            LastRestockDate = lastRestockDate;
        }

        public void ReducePrice(double amount)
        {
            if (amount > 0 && Price - amount >= 0)
            {
                Price -= amount;
            }
            else
            {
                Console.WriteLine("Неможливо зменшити ціну на задане число.");
            }
        }

        public void Display()
        {
            Console.WriteLine($"\n{Name} ({Category}, {Unit}): {Price:F2} USD, Кількість: {Quantity}, Останнє завезення: {LastRestockDate:dd.MM.yyyy}\n");
        }
    }
}
