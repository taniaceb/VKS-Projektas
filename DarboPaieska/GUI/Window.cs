using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DarboPaieska.GUI
{
    class Window:GuiObject
    {
        private Frame _border;

        public Window(int x, int y, int width, int height, char borderChar) : base(x, y, width, height)
        {
            Debug.WriteLine("Window: "+this.GetType());
            X = x;
            Y = y;
            Width = width;
            Height = height;

            _border = new Frame(x, y, width, height, borderChar);
        }

        public override void Render()
        {
            _border.Render();

        }

    }
}
