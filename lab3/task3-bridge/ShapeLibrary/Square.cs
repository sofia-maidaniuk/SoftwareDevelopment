﻿using RendererLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render("Square");
        }
    }
}
