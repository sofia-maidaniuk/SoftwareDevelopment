using System;
using ProxyLibrary;

namespace ConsoleApp_ProxyDemo
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string file1 = @"..\..\..\Files\file.txt";
            string file2 = @"..\..\..\Files\restricted_file.txt";
            string restrictionPattern = @"restricted_.*\.txt";

            IReader reader = new SmartTextReader();
            IReader checker = new SmartTextChecker();
            IReader locker = new SmartTextReaderLocker(restrictionPattern);
            IReader lockerChecker = new LockerWithChecker(restrictionPattern);

            RunTest("SmartTextReader: file.txt", ConsoleColor.Green, reader, file1);
            RunTest("SmartTextChecker: file.txt", ConsoleColor.Cyan, checker, file1);
            RunTest("Locker: restricted_file.txt", ConsoleColor.DarkYellow, locker, file2);
            RunTest("Locker: file.txt", ConsoleColor.Yellow, locker, file1);
            RunTest("Locker + Checker: restricted_file.txt", ConsoleColor.Magenta, lockerChecker, file2);
            RunTest("Locker + Checker: file.txt", ConsoleColor.Blue, lockerChecker, file1);
        }

        static void RunTest(string title, ConsoleColor color, IReader reader, string path)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n{title}");
            Console.ResetColor();

            var content = reader.ReadFileToArray(path);
            reader.DisplayByLetters(content);
        }
    }

    // Додатковий клас для комбінації SmartTextReaderLocker + SmartTextChecker
    public class LockerWithChecker : IReader
    {
        private readonly SmartTextReaderLocker _locker;
        private readonly SmartTextChecker _checker;
        private readonly string _pattern;

        public LockerWithChecker(string pattern)
        {
            _pattern = pattern;
            _locker = new SmartTextReaderLocker(pattern);
            _checker = new SmartTextChecker();
        }

        public char[][] ReadFileToArray(string filePath)
        {
            // Спершу перевіримо доступ через locker
            if (new System.Text.RegularExpressions.Regex(_pattern).IsMatch(System.IO.Path.GetFileName(filePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Access denied!");
                Console.ResetColor();
                return Array.Empty<char[]>();
            }

            return _checker.ReadFileToArray(filePath);
        }

        public void DisplayByLetters(char[][] content)
        {
            _checker.DisplayByLetters(content);
        }
    }
}
