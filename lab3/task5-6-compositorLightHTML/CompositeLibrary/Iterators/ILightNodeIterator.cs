using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Iterators
{
    public interface ILightNodeIterator
    {
        bool MoveNext();              
        LightNode Current { get; }   
        void Reset();                
    }
}
