using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Command
{
    public class ChangeTextCommand : ICommand
    {
        private readonly LightTextNode _target;
        private readonly string _newText;
        private string _oldText;

        public ChangeTextCommand(LightTextNode target, string newText)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
            _newText = newText ?? throw new ArgumentNullException(nameof(newText));
        }

        public void Execute()
        {
            _oldText = _target.Text;
            _target.Text = _newText;
        }

        public void Undo()
        {
            _target.Text = _oldText;
        }

        public string Description => $"Change text in LightTextNode to '{_newText}'";
    }
}
