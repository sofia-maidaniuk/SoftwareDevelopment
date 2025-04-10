using CompositeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyweightLibrary
{
    public class LightHtmlDocument
    {
        private LightElementFactory _factory;

        public LightNode RootNode { get; private set; }
        public LightElementNode Body { get; private set; }

        public LightHtmlDocument()
        {
            _factory = new LightElementFactory();

            RootNode = _factory.GetOrCreate("html", true, false);
            var head = _factory.GetOrCreate("head", true, false);
            Body = _factory.GetOrCreate("body", true, false);

            ((LightElementNode)RootNode).AddChild(head);
            ((LightElementNode)RootNode).AddChild(Body);
        }

        public string GetHTML()
        {
            return "<!DOCTYPE html>\n" + RootNode.OuterHtml();
        }

        public void LinesToHtml(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                LightElementNode element;

                if (i == 0)
                {
                    element = new LightElementNode("h1", DisplayType.Block, ClosingType.Double);
                }
                else if (line.Length < 20)
                {
                    element = new LightElementNode("h2", DisplayType.Block, ClosingType.Double);
                }
                else if (line.StartsWith(" ") || line.StartsWith("\t"))
                {
                    element = new LightElementNode("blockquote", DisplayType.Block, ClosingType.Double);
                }
                else
                {
                    element = new LightElementNode("p", DisplayType.Block, ClosingType.Double);
                }

                element.AddChild(new LightTextNode(line));
                Body.AddChild(element);
            }
        }

        public void LinesToHtmlWithFlyweight(string[] lines)
        {
            var h1 = _factory.GetOrCreate("h1", true, false);
            var h2 = _factory.GetOrCreate("h2", true, false);
            var blockquote = _factory.GetOrCreate("blockquote", true, false);
            var paragraph = _factory.GetOrCreate("p", true, false);

            for (int i = 0; i < lines.Length; i++)
            {
                string rawLine = lines[i];

                if (string.IsNullOrWhiteSpace(rawLine))
                    continue; 

                string line = rawLine; 

                FlyweightElNode element;

                if (i == 0)
                {
                    element = new FlyweightElNode(h1);
                }
                else if (line.Length < 20)
                {
                    element = new FlyweightElNode(h2);
                }
                else if (line.StartsWith(" ") || line.StartsWith("\t"))
                {
                    element = new FlyweightElNode(blockquote);
                }
                else
                {
                    element = new FlyweightElNode(paragraph);
                }

                element.AddChild(new LightTextNode(line));
                Body.AddChild(element);
            }
        }

    }
}
