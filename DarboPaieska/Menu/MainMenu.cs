using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.Menu
{
    class MainMenu:Window
    {
        
        private TextLine _titleTextLine;
        private Button _jobadsButton;
        private Button _cvButton;
        private Button _employerButton;

        public List<Button> MenuItem = new List<Button>();
       


        public MainMenu() : base(0, 0, 120, 30, '*')
        {

                     
            _titleTextLine = new TextLine(50, 3, 20, "DARBO PAIESKA");
            _jobadsButton = new Button(10, 6, 30, 5, "  1 - Darbo skelbimai");
            _cvButton = new Button(10, 12, 30, 5, "  2 - Ikelti CV");
            _employerButton = new Button(10, 18, 30, 5, "  3 - Darbdaviams" );

            MenuItem.Add(_jobadsButton);
            MenuItem.Add(_cvButton);
            MenuItem.Add(_employerButton);

            }

        
        public override void Render()
        {
            Console.Clear();
            
            base.Render();

            //  _titleTextBlock.Render();

            _titleTextLine.Render();
            
            for (int i = 0; i < MenuItem.Count; i++)
            {
                MenuItem[i].Render();
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}
