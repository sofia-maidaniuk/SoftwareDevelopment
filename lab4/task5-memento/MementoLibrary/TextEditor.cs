using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public class TextEditor : ICaretaker
    {
        private readonly TextDocument document;
        private readonly Stack<IMemento> history = new Stack<IMemento>();

        public TextEditor(TextDocument doc)
        {
            document = doc;
        }

        public void Write(string title, string content)
        {
            Backup();
            document.Write(title, content);
        }

        public void Backup()
        {
            history.Push(new DocumentMemento(document.GetTitle(), document.GetContent()));
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                var memento = history.Pop();
                var state = memento.GetSavedState();
                document.Write(state.Title, state.Content);
                Console.WriteLine("Undo completed.");
            }
            else
            {
                Console.WriteLine("No history to undo.");
            }
        }

        public void ShowDocument()
        {
            Console.WriteLine("Current Document:");
            Console.WriteLine(document.Read());
        }
    }
}
