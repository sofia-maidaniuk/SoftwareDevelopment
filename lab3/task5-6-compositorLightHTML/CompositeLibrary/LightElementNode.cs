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
        public Dictionary<string, string> Styles { get; } = new Dictionary<string, string>();

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
        public void AddStyle(string key, string value)
        {
            Styles[key] = value;
        }

        public void AddChild(LightNode node)
        {
            Children.Add(node);
        }

        public void RemoveChild(LightNode node)
        {
            if (Children.Contains(node))
            {
                node.OnRemoved();
                Children.Remove(node);
                Console.WriteLine($"[INFO] Child node removed from <{TagName}>");
            }
            else
            {
                Console.WriteLine($"[WARN] Attempted to remove node not in children of <{TagName}>");
            }
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

        protected override void ApplyStyles()
        {
            Console.WriteLine($"[Styles] Applied styles to <{TagName}>: {string.Join("; ", Styles.Select(s => $"{s.Key}: {s.Value}"))}");
        }

        protected override void ApplyClassList()
        {
            Console.WriteLine($"[Classes] Applied classes to <{TagName}>: {string.Join(" ", CssClasses)}");
        }

        protected override string RenderOuterHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<" + TagName);

            if (CssClasses.Any())
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");

            if (Styles.Any())
                sb.Append($" style=\"{string.Join("; ", Styles.Select(s => $"{s.Key}: {s.Value}"))}\"");

            if (Closing == ClosingType.Single)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append(">");
            sb.Append(RenderInnerHtml());
            sb.Append("</" + TagName + ">");

            return sb.ToString();
        }

        protected override string RenderInnerHtml()
        {
            var sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.Render());
            }
            return sb.ToString();
        }
        public override void OnCreated() => Console.WriteLine($"[Lifecycle] <{TagName}> created");
        public override void OnInserted() => Console.WriteLine($"[Lifecycle] <{TagName}> inserted");
        public override void OnRemoved() => Console.WriteLine($"[Lifecycle] <{TagName}> removed");
        public override void OnStylesApplied() => Console.WriteLine($"[Lifecycle] Styles applied to <{TagName}>");
        public override void OnClassListApplied() => Console.WriteLine($"[Lifecycle] Class list applied to <{TagName}>");
        public override void OnTextRendered() => Console.WriteLine($"[Lifecycle] Content rendered for <{TagName}>");

        public override string OuterHtml()
        {
            return RenderOuterHtml();
        }

        public override string InnerHtml()
        {
            return RenderInnerHtml();
        }

        public override int ChildElementsCount()
        {
            return Children.Count;
        }
    }
}