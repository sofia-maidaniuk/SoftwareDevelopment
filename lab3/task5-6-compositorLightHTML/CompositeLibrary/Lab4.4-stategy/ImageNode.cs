using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Lab4._4_stategy
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
            // Делегація створення HTML коду стратегії завантаження
            return _loadingStrategy.LoadImage(Src);
        }

        public override string InnerHtml() => string.Empty;

        public override int ChildElementsCount() => 0;
    }
}
