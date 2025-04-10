using System;
using System.Collections.Generic;
using System.IO;

namespace ProxyLibrary
{
    public class SmartTextReader : IReader
    {
        public char[][] ReadFileToArray(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[INFO] File '{filePath}' not found. Creating a sample file...");
                Console.ResetColor();

                string directory = Path.GetDirectoryName(filePath); // Отримати шлях до папки
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory); // Створити папку, якщо її немає
                }

                File.Create(filePath).Dispose(); // Створюємо файл і одразу закриваємо
            }


            List<char[]> lines = new List<char[]>();

            foreach (string line in File.ReadLines(filePath))
            {
                lines.Add(line.ToCharArray());
            }

            return lines.ToArray();
        }

        public void DisplayByLetters(char[][] content)
        {
            foreach (var row in content)
            {
                foreach (var ch in row)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
