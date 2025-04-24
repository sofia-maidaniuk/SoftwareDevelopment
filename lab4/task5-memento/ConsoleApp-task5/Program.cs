using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MementoLibrary;

namespace ConsoleApp_task5
{
    class Program
    {
        static void Main()
        {
            TextDocument doc = new TextDocument();
            ICaretaker editor = new TextEditor(doc);

            editor.Write("Draft Title", "This is the first draft.");
            editor.ShowDocument();

            editor.Write("Final Title", "This is the final content.");
            editor.ShowDocument();

            editor.Undo();
            editor.ShowDocument();
        }
    }
}
