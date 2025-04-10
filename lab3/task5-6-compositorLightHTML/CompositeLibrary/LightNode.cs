using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary
{
    public abstract class LightNode
    {
        public abstract string OuterHtml();
        public abstract string InnerHtml();
        public abstract int ChildElementsCount();
    }
}
