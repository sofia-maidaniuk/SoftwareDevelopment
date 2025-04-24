using CompositeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_task5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створення <div>
            var root = new LightElementNode("div", DisplayType.Block, ClosingType.Double);
            root.AddCssClass("container");

            var heading = new LightElementNode("h2", DisplayType.Block, ClosingType.Double);
            heading.AddCssClass("title");
            heading.AddChild(new LightTextNode("My Favorite Movies"));

            // Додаємо обробник подій до заголовка
            heading.AddEventListener("click", new ConsoleLoggerEventListener("ClickHandler"));
            heading.AddEventListener("mouseover", new ConsoleLoggerEventListener("HoverHandler"));

            // Імітація подій
            heading.TriggerEvent("click");
            heading.TriggerEvent("mouseover");

            root.AddChild(heading);

            // Додавання списку
            var list = new LightElementNode("ul", DisplayType.Block, ClosingType.Double);
            list.AddCssClass("movie-list");

            // Додавання елементів списку
            var movie1 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie1.AddChild(new LightTextNode("The Hunger Games"));

            var movie2 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie2.AddChild(new LightTextNode("Interstellar"));

            var movie3 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie3.AddChild(new LightTextNode("Inception"));

            list.AddChild(movie1);
            list.AddChild(movie2);
            list.AddChild(movie3);

            root.AddChild(list);

            // Вивід HTML
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOuter HTML:");
            Console.ResetColor();
            Console.WriteLine(root.OuterHtml());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nInner HTML:");
            Console.ResetColor();
            Console.WriteLine(root.InnerHtml());

            Console.WriteLine($"\nTotal nested nodes: {root.ChildElementsCount()}");
        }
    }
}
