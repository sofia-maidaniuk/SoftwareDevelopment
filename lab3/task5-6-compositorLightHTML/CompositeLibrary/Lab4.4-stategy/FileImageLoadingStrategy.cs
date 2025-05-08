using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompositeLibrary
{
    public class FileImageLoadingStrategy : IImageLoadingStrategy
    {
        public string LoadImage(string href)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), href);
            return File.Exists(fullPath)
                ? $"<img src=\"file://{fullPath}\" alt=\"Image from file\" />"
                : $"<!-- File not found: {fullPath} -->";
        }
    }
}
