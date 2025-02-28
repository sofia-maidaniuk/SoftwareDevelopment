using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class LimitedEditionProduct : Product
    {
        public string SpecialFeature { get; set; }

        public LimitedEditionProduct(string name, string category, string unit, double price, int quantity, DateTime lastRestockDate, string specialFeature)
            : base(name, category, unit, price, quantity, lastRestockDate)
        {
            SpecialFeature = specialFeature;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name} ({Category}, {Unit}): {Price:F2} USD, Кількість: {Quantity}, {SpecialFeature} (Limited Edition)");
        }
    }
}
