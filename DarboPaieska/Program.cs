using DarboPaieska.Menu;
using System;


namespace DarboPaieska
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.ForegroundColor = ConsoleColor.DarkRed;
           Console.BackgroundColor = ConsoleColor.DarkBlue;
            
          
            MainMenu mainMenu = new MainMenu();

            mainMenu.Render();
            Console.ReadKey();
           

        }
    }
}
