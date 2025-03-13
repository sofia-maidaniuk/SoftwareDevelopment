using System;
using Factory;
using Device;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nChoose a brand:");
            Console.WriteLine("1 - IProne");
            Console.WriteLine("2 - Kiaomi");
            Console.WriteLine("3 - Balaxy");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }

            IFactory factory;
            switch (input)
            {
                case "1":
                    factory = new IProne();
                    break;
                case "2":
                    factory = new Kiaomi();
                    break;
                case "3":
                    factory = new Balaxy();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter 1, 2, or 3.");
                    continue;
            }

            Console.WriteLine("\nChoose a device type:");
            Console.WriteLine("1 - Laptop");
            Console.WriteLine("2 - Netbook");
            Console.WriteLine("3 - EBook");
            Console.WriteLine("4 - Smartphone");
            Console.Write("Enter your choice: ");

            string deviceType = Console.ReadLine();
            IDevice device;
            switch (deviceType)
            {
                case "1":
                    device = factory.CreateLaptop();
                    break;
                case "2":
                    device = factory.CreateNetbook();
                    break;
                case "3":
                    device = factory.CreateEBook();
                    break;
                case "4":
                    device = factory.CreateSmartphone();
                    break;
                default:
                    Console.WriteLine("Invalid device type! Please enter 1, 2, 3, or 4.");
                    continue;
            }

            Console.WriteLine();
            device.DisplayInfo();
        }
    }
}
