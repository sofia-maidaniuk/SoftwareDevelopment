using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryChainOfResponsibility
{
    public abstract class SupportHandler : ISupportHandler
    {
        protected internal ISupportHandler nextHandler;
        protected Dictionary<string, string> subCategories;
        protected int complaintPriority;
        public bool RequestHandled { get; protected set; }

        public void SetNextHandler(ISupportHandler handler)
        {
            nextHandler = handler;
        }

        public ISupportHandler GetNextHandler() => nextHandler;

        public abstract void HandleRequest(int level);

        protected void DisplaySubCategories()
        {
            Console.WriteLine("\nОберіть підкатегорію:");
            foreach (var item in subCategories)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine("0 - Повернутися назад");
        }

        protected void LogAndDisplayResponse(string category, string subCategory, string response)
        {
            RequestHandled = true;
            Console.WriteLine($"\nКатегорія: {category}");
            Console.WriteLine($"Підкатегорія: {subCategory}");
            if (complaintPriority > 0)
            {
                Console.WriteLine($"Пріоритет: {complaintPriority}");
            }
            Console.WriteLine($"Відповідь: {response}\n");
        }
    }
}
