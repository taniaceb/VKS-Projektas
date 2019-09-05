using System;
using System.Collections.Generic;
using System.Text;

namespace DarboPaieska.Menu
{
    class MenuController
    {
        private JobAds _jobAds = new JobAds();
        private MainMenu _mainMenu = new MainMenu();
        private Employer _employer = new Employer();
        private string _city = "";
        private string _category = "";
        private string _company = "";
        private string _email = "";
        private string _password = "";
        private string _position = "";
        private string _jobdescription = "";


        public MenuController()
        {

        }

        public void ShowMainMenu()
        {
            _mainMenu.Render();
            ChooseMainMenuItem();
        }

        public void ShowJobAds()
        {

            _jobAds.SelectJobQuery();
            _jobAds.Render();
            JobAdsFilter();
        }

        public void ChooseMainMenuItem ()
        {
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                    case ConsoleKey.NumPad1:

                        Console.Clear();
                        ShowJobAds();
                         break;

                    case ConsoleKey.NumPad2:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        //Ivesti CV

                        break;

                    case ConsoleKey.NumPad3:
                        
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("IVESKITE EL.PASTO ADRESA IR PASPAUSKITE 'Enter' ");
                        _email = Console.ReadLine();
                        Console.WriteLine("IVESKITE SLAPTAZODI IR PASPAUSKITE 'Enter' + S");
                        _password = Console.ReadLine();
                        
                        break;

                    case ConsoleKey.S:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        _employer.FilterCompany(_email, _password);
                        _employer.Render();
                        CompanyNewJobAd();
                        break;

                }



                pressedChar = Console.ReadKey();

            }
        }

        public void CompanyNewJobAd()
        {
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                   
                    case ConsoleKey.C:

                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                       
                        Console.WriteLine("1 - IT; 2 - LOGISTIKA; 3 - FINANSAI; 4 - STATYBA; 5 - KLIENTU APTARNAVIMAS");
                        Console.WriteLine("IVESKITE KATEGORIJOS ID IR PASPAUSKITE 'Enter'");
                        _category = Console.ReadLine();
                        Console.WriteLine("IVESKITE DARBO POZICIJA IR PASPAUSKITE 'Enter'");
                        _position = Console.ReadLine();
                        Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter'");
                        _city = Console.ReadLine();
                        Console.WriteLine("IVESKITE DARBO APRASYMA IR PASPAUSKITE 'Enter' ir S");
                        _jobdescription = Console.ReadLine();
                     break;

                    case ConsoleKey.S:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        _employer.CreateAdd(Convert.ToInt32(_employer.companyID[0]), Convert.ToInt32(_category), _position, _jobdescription, _city);
                        _employer.FilterCompany(_email, _password);
                         _employer.Render();


                        break;
                }



                pressedChar = Console.ReadKey();

            }

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
