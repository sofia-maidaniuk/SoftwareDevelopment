using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeLibrary
{
    public enum DisplayType
    {
        Block,
        Inline
    }

    public enum ClosingType
    {
        Single,
        Double
    }

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

        // Підтримка подій
        private readonly Dictionary<string, List<IEventListener>> eventListeners = new Dictionary<string, List<IEventListener>>();

        public LightElementNode(string tagName, DisplayType display, ClosingType closing)
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
        }

        public void AddCssClass(string className)
        {
            if (!CssClasses.Contains(className))
            {
                CssClasses.Add(className);
            }
        }

        public void AddChild(LightNode node)
        {
            Children.Add(node);
        }

        // додавання слухача
        public void AddEventListener(string eventType, IEventListener listener)
        {
            if (!eventListeners.ContainsKey(eventType))
                eventListeners[eventType] = new List<IEventListener>();

            eventListeners[eventType].Add(listener);
        }

        // виклик подій
        public void TriggerEvent(string eventType)
        {
            if (eventListeners.ContainsKey(eventType))
            {
                foreach (var listener in eventListeners[eventType])
                {
                    listener.HandleEvent(eventType, this);
                }
            }
        }

        public override string OuterHtml()
        {
            var sb = new StringBuilder();
            sb.Append($"<{TagName}");

            if (CssClasses.Any())
            {
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
            }

            if (Closing == ClosingType.Single)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append(">");
            foreach (var child in Children)
            {
                sb.Append(child.OuterHtml());
            }

            sb.Append($"</{TagName}>");
            return sb.ToString();
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

        public override int ChildElementsCount()
        {
            return Children.Count;
        }
    }
}