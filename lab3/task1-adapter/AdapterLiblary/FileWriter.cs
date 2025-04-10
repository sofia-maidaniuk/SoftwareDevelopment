using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdapterLiblary
{
    public class FileWriter
    {
        private readonly string filePath;

        public FileWriter(string path)
        {
            filePath = path;
        }

        public void Write(string text)
        {
            File.AppendAllText(filePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(filePath, text + Environment.NewLine);
        }
    }
}
