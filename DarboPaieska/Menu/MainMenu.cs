using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.Menu
{
    class MainMenu:Window
    {
        private Button _startButton;
        private Button _quitButton;
        private TextBlock _titleTextBlock;
        private Button _jobadsButton;
        private Button _cvButton;
        private Button _employerButton;

        public List<Button> MenuItem = new List<Button>();
        private int _index = 0;


        public MainMenu() : base(0, 0, 120, 30, '*')
        {


            _titleTextBlock = new TextBlock(50, 3, 20, new List<String> { "DARBO PAIESKA  " });
            _jobadsButton = new Button(10, 6, 30, 5, "Darbo skelbimai");
            _cvButton = new Button(10, 12, 30, 5, "Ikelti CV");
            _employerButton = new Button(10, 18, 30, 5, "Ikelti darbdavio pasiulyma");

            MenuItem.Add(_jobadsButton);
            MenuItem.Add(_cvButton);
            MenuItem.Add(_employerButton);

            _startButton = new Button(40, 13, 18, 5, "Darbdaviams");
            _quitButton = new Button(60, 13, 18, 5, "Ieskantiems");

        }

        


        public override void Render()
        {
            
            base.Render();

            _titleTextBlock.Render();

            //  _startButton.Render();

            //  _quitButton.Render();

            for (int i = 0; i < MenuItem.Count; i++)
            {
                MenuItem[i].Render();
            }

            /*while (true)
            {
                for (int i = 0; i < MenuItem.Count; i++)
                {
                    if (i == _index)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        MenuItem[i].Render();
                    }
                }
            }*/


        

        // _jobadsButton.Render();
        // _cvButton.Render();
        // _employerButton.Render();

        Console.SetCursorPosition(0, 0);
        }
    }
}
