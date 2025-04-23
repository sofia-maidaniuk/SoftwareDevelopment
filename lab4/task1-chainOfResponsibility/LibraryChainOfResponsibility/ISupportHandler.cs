using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryChainOfResponsibility
{
    public interface ISupportHandler
    {
        void SetNextHandler(ISupportHandler handler);
        ISupportHandler GetNextHandler();
        void HandleRequest(int level);
        bool RequestHandled { get; }
    }
}
