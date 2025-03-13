using Device;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Balaxy : IFactory
    {
        public IDevice CreateLaptop() => new Laptop("Balaxy");
        public IDevice CreateNetbook() => new Netbook("Balaxy");
        public IDevice CreateEBook() => new EBook("Balaxy");
        public IDevice CreateSmartphone() => new Smartphone("Balaxy");
    }
}
