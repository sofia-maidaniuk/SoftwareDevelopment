using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Command
{
    public class CommandHistory
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
            Console.WriteLine($"[EXECUTE] {command.Description}");
        }

        public void UndoLast()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("[UNDO] Nothing to undo.");
                return;
            }

            var last = _history.Pop();
            last.Undo();
            Console.WriteLine($"[UNDO] {last.Description}");
        }

        public void Clear()
        {
            _history.Clear();
        }
    }
}
