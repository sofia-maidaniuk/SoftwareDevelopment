using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Visitor
{
    public class NodeCountVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextCount++;
        }

        public void Report()
        {
            Console.WriteLine($"[Visitor] Element nodes: {ElementCount}");
            Console.WriteLine($"[Visitor] Text nodes: {TextCount}");
        }
    }
}
