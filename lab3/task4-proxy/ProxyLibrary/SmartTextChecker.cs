using System;
using System.IO;
using System.Linq;

namespace ProxyLibrary
{
    public class SmartTextChecker : IReader
    {
        private readonly SmartTextReader _reader;

        public SmartTextChecker()
        {
            _reader = new SmartTextReader();
        }

        public char[][] ReadFileToArray(string filePath)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[LOG] Opening file: {filePath}");
            Console.ResetColor();

            char[][] content;
            try
            {
                content = _reader.ReadFileToArray(filePath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[LOG] Successfully read file.");
                Console.ResetColor();

                int totalLines = content.Length;
                int totalChars = content.Sum(line => line.Length);
                Console.WriteLine($"[INFO] Total lines: {totalLines}");
                Console.WriteLine($"[INFO] Total characters: {totalChars}");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[LOG] Closing file.");
                Console.ResetColor();
            }
            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {ex.Message}");
                Console.ResetColor();
                throw;
            }

            return content;
        }

        public void DisplayByLetters(char[][] content)
        {
            _reader.DisplayByLetters(content);
        }
    }
}
