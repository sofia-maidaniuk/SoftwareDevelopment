using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouseLibrary
{
    public class Money
    {
        public string Currency { get; set; }
        public int Whole { get; set; }
        public int Cents { get; set; }

        public Money(string currency, int whole = 0, int cents = 0)
        {
            Currency = currency;
            Whole = whole;
            Cents = cents;
            Normalize();
        }

        private void Normalize()
        {
            if (Cents >= 100)
            {
                Whole += Cents / 100;
                Cents %= 100;
            }
        }

        public void SetValues(int whole, int cents)
        {
            Whole = whole;
            Cents = cents;
            Normalize();
        }

        public void Display()
        {
            Console.WriteLine($"{Whole}.{Cents:D2} {Currency}\n");
        }
    }
}
