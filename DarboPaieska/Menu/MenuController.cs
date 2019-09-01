using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.Menu
{
    class MenuController
    {
        private JobAds _jobAds = new JobAds();
        private string _city = "";

        public MenuController()
        {

        }

        public void ShowJobAds()
        {

            _jobAds.SelectJobQuery();
            _jobAds.Render();
            JobAdsFilter();
        }


        public void JobAdsFilter()
        {
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                    case ConsoleKey.M:


                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter ir S'");
                        _city = Console.ReadLine();
                        break;

                    case ConsoleKey.S:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                      _jobAds.FilterCityJobQuery(_city);
                      _jobAds.Render();
                                               
                        break;



                }
                pressedChar = Console.ReadKey();

            }

        }



    }
}
