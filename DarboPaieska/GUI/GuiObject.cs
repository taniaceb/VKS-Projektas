using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.GUI
{
    abstract class GuiObject
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public GuiObject(int x, int y, int width, int height)
        {

            X = x;
            Y = y;
            Height = height;
            Width = width;

        }
        public GuiObject(int x, int y, int width)
        {
            X = x;
            Y = y;
            Width = width;

        }

        abstract public void Render();

    }
}
