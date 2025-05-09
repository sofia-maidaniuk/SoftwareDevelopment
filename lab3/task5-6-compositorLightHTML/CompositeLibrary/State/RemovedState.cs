using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.State
{
    public class RemovedState : IVisibilityState
    {
        public void OnEnter()
        {
            Console.WriteLine("[State] Element is now removed from render output.");
        }

        public void OnExit()
        {
            Console.WriteLine("[State] Element exited removed state.");
        }

        public string Render(LightElementNode element)
        {
            return string.Empty;
        }
    }
}
