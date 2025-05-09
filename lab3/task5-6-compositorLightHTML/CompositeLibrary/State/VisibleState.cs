using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.State
{
    public class VisibleState : IVisibilityState
    {
        public void OnEnter()
        {
            Console.WriteLine("[State] Element became visible.");
        }

        public void OnExit()
        {
            Console.WriteLine("[State] Element exited visible state.");
        }

        public string Render(LightElementNode element)
        {
            return element.RenderContentFromState();
        }
    }
}
