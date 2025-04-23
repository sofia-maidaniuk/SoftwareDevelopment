using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatorLibrary;

namespace ConsoleApp_task2
{
    class Program
    {
        static void Main()
        {
            var mediator = new CommandCentre();

            var runway1 = new Runway();
            var runway2 = new Runway();

            mediator.RegisterRunway(runway1);
            mediator.RegisterRunway(runway2);

            var aircraft1 = new Aircraft("Boeing 737", mediator);
            var aircraft2 = new Aircraft("Airbus A320", mediator);
            var aircraft3 = new Aircraft("Cessna 172", mediator);

            Console.WriteLine("\n--- Aircraft 1 trying to land ---");
            aircraft1.Land();

            Console.WriteLine("\n--- Aircraft 2 trying to land ---");
            aircraft2.Land();

            Console.WriteLine("\n--- Aircraft 3 trying to land ---");
            aircraft3.Land(); 

            Console.WriteLine("\n--- Aircraft 1 taking off ---");
            aircraft1.TakeOff();

            Console.WriteLine("\n--- Aircraft 3 trying to land again ---");
            aircraft3.Land(); 

            Console.WriteLine("\n--- Simulation complete ---");
        }
    }
}
