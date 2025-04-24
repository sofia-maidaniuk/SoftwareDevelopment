using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public class TextDocument : ITextDocument
    {
        private string title = string.Empty;
        private string content = string.Empty;

        public void Write(string newTitle, string newContent)
        {
            title = newTitle;
            content = newContent;
        }

        public string Read()
        {
            return $"Title: {title}\nContent: {content}";
        }

        public string GetTitle() => title;
        public string GetContent() => content;
    }
}
