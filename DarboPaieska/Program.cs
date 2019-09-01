using DarboPaieska.Menu;
using System;
using System.Data.SqlClient;

namespace DarboPaieska
{
    class Program
    {
        static void Main(string[] args)
        {

                     
            Console.BackgroundColor = ConsoleColor.Gray;
            MenuController menuController = new MenuController();
            // MainMenu mainMenu = new MainMenu();
            menuController.ShowJobAds();
            // mainMenu.Render();
           // jobAds.SelectJobQuery();
          //  jobAds.Render();
            Console.ReadKey();
           

        }
    }
}
