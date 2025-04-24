using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public class DocumentMemento : IMemento
    {
        private readonly string title;
        private readonly string content;

        public DocumentMemento(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public (string Title, string Content) GetSavedState()
        {
            return (title, content);
        }
    }
}
