using CompositeLibrary;
using System;
using System.Text;

namespace ConsoleApp_MKR1_template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== DEMO: Шаблонний метод ===");

            var div = new LightElementNode("div", DisplayType.Block, ClosingType.Double);
            div.AddCssClass("container");
            div.AddStyle("padding", "10px");
            div.AddStyle("color", "red");

            var paragraph = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
            paragraph.AddCssClass("text");
            paragraph.AddChild(new LightTextNode("Привіт!"));

            // Додаємо <p> в <div>
            div.AddChild(paragraph);

            Console.WriteLine("\n=== Render #1 (до видалення) ===");
            Console.WriteLine(div.Render());

            Console.WriteLine("\n=== Видаляємо <p> ===");
            div.RemoveChild(paragraph);

            Console.WriteLine("\n=== Render #2 (після видалення) ===");
            Console.WriteLine(div.Render());

            Console.WriteLine("\n=== Готово ===");
        }
    }
}
