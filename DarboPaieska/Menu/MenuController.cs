using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.Menu
{
    class MenuController
    {
        private JobAds _jobAds = new JobAds();
        private string _city = "";
        private string _category = "";
        private string _company = "";

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

                    case ConsoleKey.F:


                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter'");
                        _city = Console.ReadLine();
                        Console.WriteLine("IVESKITE DARBO SRITI IR PASPAUSKITE 'Enter'");
                        _category = Console.ReadLine();
                        Console.WriteLine("IVESKITE IMONE IR PASPAUSKITE 'Enter' + P");
                        _company = Console.ReadLine();
                        break;

                    case ConsoleKey.P:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        _jobAds.FilterAllJobQuery(_city,_category,_company);
                        _jobAds.Render();

                        break;

                }



                pressedChar = Console.ReadKey();

            }

        }



    }
}
