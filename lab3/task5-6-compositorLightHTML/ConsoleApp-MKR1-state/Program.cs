using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeLibrary;
using CompositeLibrary.State;

namespace ConsoleApp_MKR1_state
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Demo: Стан ===\n");

            var section = new LightElementNode("section", DisplayType.Block, ClosingType.Double);
            section.AddCssClass("content");
            section.AddChild(new LightTextNode("Це вміст секції."));

            Console.WriteLine("\n[Default: VisibleState]");
            Console.WriteLine(section.RenderWithState());

            Console.WriteLine("\n[Switch to HiddenState]");
            section.SetVisibilityState(new HiddenState());
            Console.WriteLine(section.RenderWithState());

            Console.WriteLine("\n[Switch to RemovedState]");
            section.SetVisibilityState(new RemovedState());
            Console.WriteLine(section.RenderWithState());

            Console.WriteLine("\n[Back to VisibleState]");
            section.SetVisibilityState(new VisibleState());
            Console.WriteLine(section.RenderWithState());

            Console.WriteLine("\n=== Done ===");
        }
    }
}
