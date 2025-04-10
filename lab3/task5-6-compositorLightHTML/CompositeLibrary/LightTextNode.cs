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
    }
}
