using System;
using System.Collections.Generic;
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
            Label = label;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            if (Width > Label.Length)
            {
                int offset = (Width - Label.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }
            
            Console.Write(Label);
        }
    }
}
