using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterLiblary;

namespace ConsoleApp_task1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ILogger consoleLogger = new Logger();
            consoleLogger.Log("System initialized.");
            consoleLogger.Warn("Memory usage high.");
            consoleLogger.Error("Disk read error.");

            Console.WriteLine("\nWriting to file...\n");

            FileWriter fileWriter = new FileWriter("log.txt");
            ILogger fileLogger = new FileLoggerAdapter(fileWriter);
            fileLogger.Log("Data saved.");
            fileLogger.Warn("Low battery.");
            fileLogger.Error("Connection lost.");

            Console.WriteLine("Check 'log.txt' for file logs.");
        }
    }
}
