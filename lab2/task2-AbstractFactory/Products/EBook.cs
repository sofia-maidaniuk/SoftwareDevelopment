using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class EBook : IDevice
    {
        public string Name { get; }

        public EBook(string brand)
        {
            Name = $"{brand} EBook";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Device: {Name}");
        }
    }
}
