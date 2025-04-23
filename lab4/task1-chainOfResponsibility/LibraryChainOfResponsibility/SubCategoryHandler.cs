using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryChainOfResponsibility
{
    public class SubCategoryHandler : SupportHandler
    {
        private readonly string _categoryName;
        private readonly string _response;

        public SubCategoryHandler(string categoryName, int priority, Dictionary<string, string> subCategories, string response)
        {
            _categoryName = categoryName;
            complaintPriority = priority;
            this.subCategories = subCategories;
            _response = response;
        }

        public override void HandleRequest(int level)
        {
            Console.WriteLine($"\n=== {_categoryName} ===");
            DisplaySubCategories();

            string input = Console.ReadLine();
            if (subCategories.ContainsKey(input))
            {
                LogAndDisplayResponse(_categoryName, subCategories[input], _response);
            }
            else if (input == "0")
            {
                RequestHandled = false;
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(level);
            }
            else
            {
                Console.WriteLine("\nЖоден рівень не підійшов. Почнімо спочатку.\n");
                RequestHandled = false;
            }
        }
    }

}
