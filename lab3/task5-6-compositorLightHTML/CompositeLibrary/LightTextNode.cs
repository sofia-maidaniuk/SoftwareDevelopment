using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary
{
    public class LightTextNode : LightNode
    {
        public string Text { get; set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHtml()
        {
            return Text;
        }

        public override string InnerHtml()
        {
            return Text;
        }

        public override int ChildElementsCount()
        {
            return 0;
        }

        protected override void ApplyStyles()
        {
            // Текстовий вузол не має стилів, але фіксуємо виклик для демонстрації
            Console.WriteLine("[Styles] No styles to apply for LightTextNode.");
        }

        protected override void ApplyClassList()
        {
            // Текстовий вузол не має класів, але фіксуємо виклик для демонстрації
            Console.WriteLine("[Classes] No class list to apply for LightTextNode.");
        }

        protected override string RenderOuterHtml()
        {
            return Text;
        }

        protected override string RenderInnerHtml()
        {
            return Text;
        }

        // Життєві хуки (демо)
        public override void OnCreated() => Console.WriteLine("[Lifecycle] LightTextNode created");
        public override void OnInserted() => Console.WriteLine("[Lifecycle] LightTextNode inserted");
        public override void OnTextSanitize() => Console.WriteLine("[Lifecycle] LightTextNode text sanitized");
        public override void OnTextRendered() => Console.WriteLine("[Lifecycle] LightTextNode text rendered");
    }
}
