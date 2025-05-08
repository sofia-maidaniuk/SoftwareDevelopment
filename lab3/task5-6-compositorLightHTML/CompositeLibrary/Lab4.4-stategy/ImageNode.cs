using System;
using CompositeLibrary.Lab4._4_stategy;

namespace CompositeLibrary
{
    public class ImageNode : LightNode
    {
        public string Src { get; }
        private IImageLoadingStrategy _loadingStrategy;

        public ImageNode(string src, IImageLoadingStrategy strategy)
        {
            Src = src;
            _loadingStrategy = strategy;
        }

        public void SetStrategy(IImageLoadingStrategy strategy)
        {
            _loadingStrategy = strategy;
        }

        public override string OuterHtml()
        {
            return RenderOuterHtml(); // Використовуємо шаблонний метод
        }

        public override string InnerHtml() => string.Empty;

        public override int ChildElementsCount() => 0;

        // Реалізація шаблонного методу
        protected override void ApplyStyles()
        {
            Console.WriteLine("[ImageNode] No styles to apply.");
        }

        protected override void ApplyClassList()
        {
            Console.WriteLine("[ImageNode] No class list to apply.");
        }

        protected override string RenderOuterHtml()
        {
            return _loadingStrategy.LoadImage(Src);
        }

        protected override string RenderInnerHtml()
        {
            return string.Empty;
        }

        // життєві хуки
        public override void OnCreated() => Console.WriteLine("[Lifecycle] ImageNode created");
        public override void OnInserted() => Console.WriteLine("[Lifecycle] ImageNode inserted");
        public override void OnRemoved() => Console.WriteLine("[Lifecycle] ImageNode removed");
        public override void OnTextRendered() => Console.WriteLine("[Lifecycle] ImageNode rendered");
    }
}
