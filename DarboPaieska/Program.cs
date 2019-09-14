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
            menuController.ShowWindow();
            Console.ReadKey();


        }
    }
}
