using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Smartphone : IDevice
    {
        public string Name { get; }

        public Smartphone(string brand)
        {
            Name = $"{brand} Smartphone";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Device: {Name}");
        }
    }
}
