using CompositeLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightLibrary
{
    public class FlyweightElNode : LightNode
    {
        private LightElementNode _sharedElement;
        public List<LightNode> Children { get; set; }

        public FlyweightElNode(LightElementNode sharedElement)
        {
            _sharedElement = sharedElement;
            Children = new List<LightNode>();
        }

        public void AddChild(LightNode node)
        {
            if (_sharedElement.Closing == ClosingType.Single)
                return;

            Children.Add(node);
        }

        public override string InnerHtml()
        {
            var sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.OuterHtml());
            }
            return sb.ToString();
        }

        public override string OuterHtml()
        {
            var sb = new StringBuilder();
            sb.Append($"<{_sharedElement.TagName}");

            if (_sharedElement.CssClasses.Any())
            {
                sb.Append($" class=\"{string.Join(" ", _sharedElement.CssClasses)}\"");
            }

            if (_sharedElement.Closing == ClosingType.Single)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append(">");
            sb.Append(InnerHtml());
            sb.Append($"</{_sharedElement.TagName}>");

            return sb.ToString();
        }

        public override int ChildElementsCount()
        {
            int count = 0;

            foreach (var child in Children)
            {
                count += 1 + child.ChildElementsCount();
            }

            return count;
        }
    }
}
