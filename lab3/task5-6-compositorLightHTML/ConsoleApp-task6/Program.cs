using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeLibrary;
using FlyweightLibrary;
using System.IO;

namespace ConsoleApp_task6
{
    class Program
    {
        static void Main()
        {
            string filePath = @"..\..\..\Files\book.txt";

            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[INFO] File '{filePath}' not found. Creating an empty file...");
                Console.ResetColor();
                File.WriteAllText(filePath, "Default Title\nShort line\n This is indented\nNormal paragraph text here.");
            }

            string[] lines = File.ReadAllLines(filePath);

            var stopwatch = Stopwatch.StartNew();
            var doc = new LightHtmlDocument();
            doc.LinesToHtmlWithFlyweight(lines);
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===== Generated HTML =====\n");
            Console.ResetColor();
            Console.WriteLine(doc.GetHTML());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Statistics =====");
            Console.ResetColor();
            Console.WriteLine($"Total lines in file: {lines.Length}");
            Console.WriteLine($"Total nested elements: {doc.Body.ChildElementsCount()}");
            Console.WriteLine($"HTML tree construction time: {stopwatch.ElapsedMilliseconds} ms");

            // Memory usage analysis
            GC.Collect();
            long usedMemory = Process.GetCurrentProcess().PrivateMemorySize64 / 1024;
            Console.WriteLine($"Estimated memory usage: {usedMemory} KB");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}