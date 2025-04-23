using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryChainOfResponsibility
{
    public static class SupportHandlerFactory
    {
        public static List<ISupportHandler> CreateDefaultHandlers()
        {
            return new List<ISupportHandler>
            {
                new SubCategoryHandler("Базова підтримка", 1,
                    new Dictionary<string, string>
                    {
                        {"1", "Зміна тарифного плану"},
                        {"2", "Активація SIM-карти"}
                    },
                    "Ваш запит оброблено на базовому рівні підтримки."),

                new SubCategoryHandler("Технічна підтримка", 2,
                    new Dictionary<string, string>
                    {
                        {"1", "Нестабільний сигнал"},
                        {"2", "Помилка з'єднання з мережею"}
                    },
                    "Ваш запит прийнято на технічний розгляд."),

                new SubCategoryHandler("Фінансова підтримка", 3,
                    new Dictionary<string, string>
                    {
                        {"1", "Невірне списання коштів"},
                        {"2", "Неотримання бонусів"}
                    },
                    "Запит передано до бухгалтерії."),

                new SubCategoryHandler("Підтримка спеціаліста", 4,
                    new Dictionary<string, string>
                    {
                        {"1", "Спірні або складні випадки"}
                    },
                    "Ваш запит буде розглянуто старшим спеціалістом.")
            };
        }
    }
}
