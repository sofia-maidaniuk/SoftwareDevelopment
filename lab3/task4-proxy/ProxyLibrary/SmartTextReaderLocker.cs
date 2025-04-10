using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProxyLibrary
{
    public class SmartTextReaderLocker : IReader
    {
        private readonly SmartTextReader _reader;
        private readonly Regex _blockedPattern;

        public SmartTextReaderLocker(string pattern)
        {
            _reader = new SmartTextReader();
            _blockedPattern = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public char[][] ReadFileToArray(string filePath)
        {
            if (_blockedPattern.IsMatch(Path.GetFileName(filePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Access denied!");
                Console.ResetColor();
                return Array.Empty<char[]>();
            }

            return _reader.ReadFileToArray(filePath);
        }

        public void DisplayByLetters(char[][] content)
        {
            _reader.DisplayByLetters(content);
        }
    }
}
