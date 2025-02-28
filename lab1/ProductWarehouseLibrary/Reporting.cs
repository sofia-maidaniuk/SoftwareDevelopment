using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class Reporting
    {
        public void RegisterArrival(Warehouse warehouse, Product product, int quantity)
        {
            product.Quantity += quantity;
            product.LastRestockDate = DateTime.Now;
            Console.WriteLine($"\nПрибуткова накладна: Додано {quantity} {product.Unit} {product.Name} ({product.Category}).\n");
        }

        public void RegisterShipment(Warehouse warehouse, Product product, int quantity)
        {
            if (product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                Console.WriteLine($"\nВидаткова накладна: Відвантажено {quantity} {product.Unit} {product.Name} ({product.Category}).\n");
            }
            else
            {
                Console.WriteLine("\nНедостатньо товару для відвантаження.");
            }
        }

        public void InventoryReport(Warehouse warehouse)
        {
            Console.WriteLine("Звіт по інвентаризації:");
            foreach (var product in warehouse.Products)
            {
                product.Display();
            }
        }
    }
}
