using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using RendererLibrary;

namespace ConsoleApp_task3
{
    class Program
    {
        static void Main()
        {
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Shape triangle = new Triangle(vectorRenderer);
            Shape square = new Square(rasterRenderer);
            Shape circle = new Circle(vectorRenderer);

            triangle.Draw();  //  Triangle as vectors.
            square.Draw();    //  Square as pixels.
            circle.Draw();    //  Circle as vectors.
        }
    }

}
