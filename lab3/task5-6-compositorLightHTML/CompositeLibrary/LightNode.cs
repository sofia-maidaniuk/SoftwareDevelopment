using CompositeLibrary.Visitor;
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
        public abstract void Accept(ILightNodeVisitor visitor);
        public string Render()
        {
            OnCreated();
            ApplyStyles();
            OnStylesApplied();
            ApplyClassList();
            OnClassListApplied();
            OnTextSanitize();
            string html = RenderOuterHtml();
            OnTextRendered();
            OnInserted();
            return html;
        }
        public virtual void OnCreated() { }
        public virtual void OnInserted() { }
        public virtual void OnRemoved() { }
        public virtual void OnStylesApplied() { }
        public virtual void OnClassListApplied() { }
        public virtual void OnTextRendered() { }
        public virtual void OnTextSanitize() { }

        // Абстрактні методи, які реалізують логіку рендерингу
        protected abstract void ApplyStyles();
        protected abstract void ApplyClassList();
        protected abstract string RenderOuterHtml();
        protected abstract string RenderInnerHtml();
    }
}
