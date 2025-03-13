using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Laptop : IDevice
    {
        public string Name { get; }

        public Laptop(string brand)
        {
            Name = $"{brand} Laptop";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Device: {Name}");
        }
    }
}
