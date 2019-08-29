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


        public MainMenu() : base(0, 0, 120, 30, '*')
        {
            _titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "GAME DICE", "   ", "Main Menu" });

            _startButton = new Button(40, 13, 18, 5, "P - Play");
            //_startButton.SetActive();


            _quitButton = new Button(60, 13, 18, 5, "Q - Quit");


        }

        public override void Render()
        {
            base.Render();

            _titleTextBlock.Render();

            _startButton.Render();

            _quitButton.Render();


            Console.SetCursorPosition(0, 0);
        }
    }
}
