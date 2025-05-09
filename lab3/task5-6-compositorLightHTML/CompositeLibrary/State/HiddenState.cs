using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.State
{
    public class HiddenState : IVisibilityState
    {
        public void OnEnter()
        {
            Console.WriteLine("[State] Element hidden with style 'display: none'.");
        }

        public void OnExit()
        {
            Console.WriteLine("[State] Element exited hidden state.");
        }

        public string Render(LightElementNode element)
        {
            var sb = new StringBuilder();
            sb.Append("<" + element.TagName);

            if (element.CssClasses.Count > 0)
                sb.Append($" class=\"{string.Join(" ", element.CssClasses)}\"");

            sb.Append(" style=\"display: none\"");

            if (element.Closing == ClosingType.Single)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append(">");
            sb.Append(element.RenderInnerContentFromState());
            sb.Append("</" + element.TagName + ">");
            return sb.ToString();
        }
    }
}
