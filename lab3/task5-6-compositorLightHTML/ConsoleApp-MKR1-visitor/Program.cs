using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeLibrary;
using CompositeLibrary.Visitor;

namespace ConsoleApp_MKR1_visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Demo: Відвідувач ===\n");

            var root = new LightElementNode("div", DisplayType.Block, ClosingType.Double);
            root.AddCssClass("container");

            var header = new LightElementNode("h1", DisplayType.Block, ClosingType.Double);
            header.AddChild(new LightTextNode("Заголовок сторінки"));

            var paragraph = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
            paragraph.AddCssClass("description");
            paragraph.AddChild(new LightTextNode("Це текстовий блок з описом."));

            root.AddChild(header);
            root.AddChild(paragraph);

            Console.WriteLine("HTML structure:");
            Console.WriteLine(root.OuterHtml());

            var textVisitor = new TextCollectorVisitor();
            root.Accept(textVisitor);

            Console.WriteLine("\nCollected Text:");
            Console.WriteLine(textVisitor.GetCollectedText());

            Console.WriteLine("\n=== Done ===");
        }
    }
}
