using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public interface ITextDocument
    {
        void Write(string newTitle, string newContent);
        string Read();
    }
}
