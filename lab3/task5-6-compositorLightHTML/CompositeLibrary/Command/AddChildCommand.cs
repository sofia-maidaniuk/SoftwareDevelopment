using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Command
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private int _insertIndex = -1;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
            _child = child ?? throw new ArgumentNullException(nameof(child));
        }

        public void Execute()
        {
            _insertIndex = _parent.Children.Count;
            _parent.AddChild(_child);
        }

        public void Undo()
        {
            if (_insertIndex >= 0 && _parent.Children.Count > _insertIndex && _parent.Children[_insertIndex] == _child)
            {
                _parent.RemoveChild(_child);
            }
        }

        public string Description => $"Add <{_child.GetType().Name}> to <{_parent.TagName}>";
    }
}
