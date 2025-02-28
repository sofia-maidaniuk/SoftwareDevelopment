using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class Warehouse
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Товари на складі:");
            if (Products.Count == 0)
            {
                Console.WriteLine("Склад порожній.");
                return;
            }

            for (int i = 0; i < Products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                Products[i].Display();  
            }
        }

    }
}
