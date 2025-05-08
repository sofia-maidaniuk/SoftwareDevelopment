using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeLibrary;

namespace ConsoleApp_MKR1_iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== DEMO: Ітератор ===\n");

            // Побудова дерева HTML
            var root = new LightElementNode("div", DisplayType.Block, ClosingType.Double);
            root.AddCssClass("root");

            var section = new LightElementNode("section", DisplayType.Block, ClosingType.Double);
            section.AddCssClass("section");

            var p1 = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
            p1.AddCssClass("paragraph");
            p1.AddChild(new LightTextNode("Це перший абзац."));

            var p2 = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
            p2.AddCssClass("paragraph");
            p2.AddChild(new LightTextNode("Це другий абзац."));

            section.AddChild(p1);
            section.AddChild(p2);
            root.AddChild(section);

            // Обхід у глибину
            Console.WriteLine("Depth-First Traversal:");
            var depthIterator = root.CreateDepthIterator();
            while (depthIterator.MoveNext())
            {
                var node = depthIterator.Current;
                Console.WriteLine($"[DF] {node.OuterHtml()}");
            }

            Console.WriteLine();

            // Обхід у ширину
            Console.WriteLine("Breadth-First Traversal:");
            var breadthIterator = root.CreateBreadthIterator();
            while (breadthIterator.MoveNext())
            {
                var node = breadthIterator.Current;
                Console.WriteLine($"[BF] {node.OuterHtml()}");
            }

            Console.WriteLine("\n=== Done ===");
        }
    }
}
