using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Lab4._4_stategy
{
    public class NetworkImageLoadingStrategy : IImageLoadingStrategy
    {
        public string LoadImage(string href)
        {
            try
            {
                Console.WriteLine($"[NET] Attempting to download: {href}");

                var request = WebRequest.Create(href);
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            byte[] imageData = memoryStream.ToArray();

                            Console.WriteLine($"[NET] Download successful ({imageData.Length} bytes)");

                            Console.Write("[NET] First bytes: ");
                            for (int i = 0; i < Math.Min(10, imageData.Length); i++)
                            {
                                Console.Write($"{imageData[i]:X2} ");
                            }
                            Console.WriteLine("...\n");

                            return $"<img src=\"{href}\" alt=\"Image from network\" />";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NET] Download failed: {ex.Message}");
                return $"<!-- Failed to load image from: {href} -->";
            }
        }
    }
}
