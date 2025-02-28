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
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i].Name} ({Products[i].Category}) - {Products[i].Price:F2} USD");
            }
        }
    }
}
