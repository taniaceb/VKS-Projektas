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
            
            
            //  menuController.ShowJobAds();
            menuController.ShowMainMenu();

            // mainMenu.Render();
           // jobAds.SelectJobQuery();
          //  jobAds.Render();
            Console.ReadKey();
           

        }
    }
}
