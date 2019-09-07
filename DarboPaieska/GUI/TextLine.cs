using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DarboPaieska.GUI
{
    class TextLine : GuiObject
    {
        private string _label;

        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
               
            }
        }
        public TextLine(int x, int y, int width, string label) : base(x, y, width)
        {
            Debug.WriteLine($"Create textline {x}, {y}     ?{label}");
            Label = label;
        }

        public override void Render()
        {
            //Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(Label);
        }
    }
}
