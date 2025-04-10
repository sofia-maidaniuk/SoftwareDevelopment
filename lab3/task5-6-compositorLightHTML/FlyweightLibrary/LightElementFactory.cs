using System;
using System.Collections.Generic;
using CompositeLibrary;

namespace FlyweightLibrary
{
    public class LightElementFactory
    {
        private readonly Dictionary<string, LightElementNode> _elementPool = new Dictionary<string, LightElementNode>();

        public LightElementNode GetOrCreate(string tagName, bool block = true, bool selfClosing = false)
        {
            string signature = $"{tagName}_{block}_{selfClosing}";

            if (!_elementPool.ContainsKey(signature))
            {
                var display = block ? DisplayType.Block : DisplayType.Inline;
                var closing = selfClosing ? ClosingType.Single : ClosingType.Double;

                _elementPool[signature] = new LightElementNode(tagName, display, closing);
            }

            return _elementPool[signature];
        }

        public LightElementNode GenerateElementWithText(string tagName, string content, bool block = true)
        {
            var node = new LightElementNode(
                tagName,
                block ? DisplayType.Block : DisplayType.Inline,
                ClosingType.Double
            );

            node.AddChild(new LightTextNode(content));
            return node;
        }
    }
}
