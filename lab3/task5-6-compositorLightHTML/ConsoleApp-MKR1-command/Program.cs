using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeLibrary;
using CompositeLibrary.Command;

namespace ConsoleApp_MKR1_command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Підготовка вузлів
            var section = new LightElementNode("section", DisplayType.Block, ClosingType.Double);
            var paragraph = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
            var textNode = new LightTextNode("Старий текст");

            var history = new CommandHistory();

            history.ExecuteCommand(new AddChildCommand(paragraph, textNode));
            history.ExecuteCommand(new AddChildCommand(section, paragraph));
            history.ExecuteCommand(new AddClassCommand(section, "highlight"));
            history.ExecuteCommand(new ChangeTextCommand(textNode, "Новий текст"));

            Console.WriteLine("\nHTML після команд:\n");
            Console.WriteLine(section.Render());

            history.UndoLast(); 
            history.UndoLast(); 

            Console.WriteLine("\nHTML після Undo:\n");
            Console.WriteLine(section.Render());
        }
    }
}
