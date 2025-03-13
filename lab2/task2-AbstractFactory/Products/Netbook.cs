using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Netbook : IDevice
    {
        public string Name { get; }

        public Netbook(string brand)
        {
            Name = $"{brand} Netbook";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Device: {Name}");
        }
    }
}
