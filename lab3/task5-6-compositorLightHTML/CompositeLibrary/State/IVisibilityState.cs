using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.State
{
    public interface IVisibilityState
    {
        void OnEnter();
        void OnExit();
        string Render(LightElementNode element);
    }
}
