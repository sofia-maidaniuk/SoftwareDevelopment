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
            // Створення  <div>
            var root = new LightElementNode("div", DisplayType.Block, ClosingType.Double);
            root.CssClasses.Add("container");

            var heading = new LightElementNode("h2", DisplayType.Block, ClosingType.Double);
            heading.CssClasses.Add("title");
            heading.Children.Add(new LightTextNode("My Favorite Movies"));
            root.Children.Add(heading);

            // Додавання списку 
            var list = new LightElementNode("ul", DisplayType.Block, ClosingType.Double);
            list.CssClasses.Add("movie-list");

            // Додавання елементів списку 
            var movie1 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie1.Children.Add(new LightTextNode("The Hunger Games"));

            var movie2 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie2.Children.Add(new LightTextNode("Interstellar"));

            var movie3 = new LightElementNode("li", DisplayType.Block, ClosingType.Double);
            movie3.Children.Add(new LightTextNode("Inception"));

            list.Children.Add(movie1);
            list.Children.Add(movie2);
            list.Children.Add(movie3);

            root.Children.Add(list);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Outer HTML:");
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
