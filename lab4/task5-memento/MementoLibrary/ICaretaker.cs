using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public interface ICaretaker
    {
        void Backup();
        void Undo();
        void Write(string title, string content);
        void ShowDocument();
    }
}
