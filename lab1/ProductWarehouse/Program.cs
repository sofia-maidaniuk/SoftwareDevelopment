using System;
using System.Text;
using ProductWarehouseLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;

        Warehouse warehouse = new Warehouse();
        Reporting reporting = new Reporting();

        warehouse.AddProduct(new Product("Ноутбук", "Електроніка", "шт.", 1200, 10, DateTime.Now.AddDays(-5)));
        warehouse.AddProduct(new Product("Телефон", "Електроніка", "шт.", 800, 20, DateTime.Now.AddDays(-3)));
        warehouse.AddProduct(new Product("Планшет", "Електроніка", "шт.", 500, 15, DateTime.Now.AddDays(-7)));

        while (true)
        {
            warehouse.DisplayProducts();
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1 - Додати новий товар");
            Console.WriteLine("2 - Зареєструвати надходження товару");
            Console.WriteLine("3 - Зареєструвати відвантаження товару");
            Console.WriteLine("4 - Звіт по інвентаризації");
            Console.WriteLine("5 - Зменшити ціну товару");
            Console.WriteLine("0 - Вихід");
            Console.Write("\nВаш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out int action) || action == 0)
            {
                Console.WriteLine("Вихід із програми.");
                break;
            }

            switch (action)
            {
                case 1:
                    AddNewProduct(warehouse);
                    break;
                case 2:
                    RegisterProductArrival(warehouse, reporting);
                    break;
                case 3:
                    RegisterProductShipment(warehouse, reporting);
                    break;
                case 4:
                    reporting.InventoryReport(warehouse);
                    break;
                case 5:
                    ReduceProductPrice(warehouse);
                    break;
                default:
                    Console.WriteLine("Невідома команда.");
                    break;
            }
        }
    }

    // Метод для додавання нового товару
    static void AddNewProduct(Warehouse warehouse)
    {
        Product newProduct = AddNewItem.CreateProduct();
        warehouse.AddProduct(newProduct);
        Console.WriteLine("Новий товар додано.");
    }

    // Метод для реєстрації надходження товару

    static Product GetSelectedProduct(Warehouse warehouse)
    {
        Console.Write("\nВиберіть номер товару: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > warehouse.Products.Count)
        {
            Console.WriteLine("Некоректний вибір товару.");
            return null;
        }
        return warehouse.Products[choice - 1];
    }

    static void RegisterProductArrival(Warehouse warehouse, Reporting reporting)
    {
        Product selectedProduct = GetSelectedProduct(warehouse);
        if (selectedProduct == null) return;


        Console.Write("Введіть кількість надходження: ");
        if (int.TryParse(Console.ReadLine(), out int arrivalQty))
        {
            reporting.RegisterArrival(warehouse, selectedProduct, arrivalQty);
        }
        else
        {
            Console.WriteLine("Некоректне значення кількості.");
        }
    }

    // Метод для реєстрації відвантаження товару
    static void RegisterProductShipment(Warehouse warehouse, Reporting reporting)
    {
        Product selectedProduct = GetSelectedProduct(warehouse);
        if (selectedProduct == null) return;

        Console.Write("Введіть кількість для відвантаження: ");
        if (int.TryParse(Console.ReadLine(), out int shipmentQty))
        {
            reporting.RegisterShipment(warehouse, selectedProduct, shipmentQty);
        }
        else
        {
            Console.WriteLine("Некоректне значення кількості.");
        }
    }

    // Метод для зменшення ціни товару
    static void ReduceProductPrice(Warehouse warehouse)
    {
        Product priceProduct = GetSelectedProduct(warehouse);
        if (priceProduct == null) return;

        Console.Write("Введіть суму, на яку потрібно зменшити ціну: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            priceProduct.ReducePrice(amount);
            priceProduct.Display();
        }
        else
        {
            Console.WriteLine("Некоректне значення суми.");
        }
    }
}
