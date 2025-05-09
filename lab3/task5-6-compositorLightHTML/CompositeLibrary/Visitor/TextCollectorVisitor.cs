using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Visitor
{
    public class TextCollectorVisitor : ILightNodeVisitor
    {
        private readonly StringBuilder _textBuilder = new StringBuilder();

        public void VisitElement(LightElementNode element)
        {
            // Нічого не робимо для тегів
        }

        public void VisitText(LightTextNode text)
        {
            _textBuilder.Append(text.Text + " ");
        }

        public string GetCollectedText()
        {
            return _textBuilder.ToString().Trim();
        }
    }
}
