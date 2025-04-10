using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLibrary
{
    public interface IReader
    {
        char[][] ReadFileToArray(string filePath);
        void DisplayByLetters(char[][] content);
    }
}
