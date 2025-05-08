using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary
{
    public class ConsoleLoggerEventListener : IEventListener
    {
        private readonly string _name;

        public ConsoleLoggerEventListener(string name)
        {
            _name = name;
        }

        public void HandleEvent(string eventType, LightElementNode target)
        {
            Console.WriteLine($"[{_name}] Event '{eventType}' triggered on <{target.TagName}>.");
        }
    }
}
