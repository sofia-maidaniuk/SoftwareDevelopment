using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Command
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _target;
        private readonly string _className;

        public AddClassCommand(LightElementNode target, string className)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
            _className = className ?? throw new ArgumentNullException(nameof(className));
        }

        public void Execute()
        {
            _target.AddCssClass(_className);
        }

        public void Undo()
        {
            _target.CssClasses.Remove(_className);
        }

        public string Description => $"Add class '{_className}' to <{_target.TagName}>";
    }
}
