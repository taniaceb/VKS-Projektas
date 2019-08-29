using DarboPaieska.Menu;
using System;

namespace DarboPaieska
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();

            mainMenu.Render();
        }
    }
}
