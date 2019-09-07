using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string _jobid;
        private int _result = 0;


        public MenuController()
        {

        }

       public void ShowWindow()
        {
            while(_result==0)
            {
                Console.Clear();
                ShowMainMenu();
            }

            while (_result == 1)
            {
                Console.Clear();
                ShowJobAds();
            }

            while (_result==3)
            {
                Console.Clear();
                ShowEmployers();
            }
        }


        public void ShowMainMenu()
        {
            Console.Clear();
            Debug.WriteLine("ShowMainMenu");
            _mainMenu.Render();
            ChooseMainMenuItem();
        }

        public void ShowJobAds()
        {
            Console.Clear();
            Debug.WriteLine("ShowJobAds");
            _jobAds.SelectJobQuery();
            _jobAds.Render();
            JobAdsFilter();
        }

        public void ShowEmployers()
        {
            Console.Clear();
            Debug.WriteLine("ShowEmployers");
            Console.Clear();
            Console.SetCursorPosition(0, 0);


            Console.WriteLine("IVESKITE EL.PASTO ADRESA IR PASPAUSKITE 'Enter' ");
            _email = Console.ReadLine();
            while (_email == "")
            {
                Console.WriteLine("IVESKITE EL.PASTO ADRESA IR PASPAUSKITE 'Enter' ");
                _email = Console.ReadLine();
            }
            Console.WriteLine("IVESKITE SLAPTAZODI IR PASPAUSKITE 'Enter' ");
            _password = Console.ReadLine();
            while (_password == "")
            {
                Console.WriteLine("IVESKITE SLAPTAZODI IR PASPAUSKITE 'Enter' ");
                _password = Console.ReadLine();
            }

            Console.Clear();
            _employer.FilterCompany(_email, _password);
            _employer.Render();
            CompanyCreateDeleteJobAd();
        }


        public void ChooseMainMenuItem()
        {
            Debug.WriteLine("ChooseMainMenuItem");
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                    case ConsoleKey.NumPad1:

                        
                        JobAdsReturn();
                        ShowWindow();
                       
                        Console.SetCursorPosition(0, 0);

                        break;

                    case ConsoleKey.NumPad2:

                        // Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        //Ivesti CV

                        break;

                    case ConsoleKey.NumPad3:

                        //ShowEmployers();
                        EmployerReturn();
                        ShowWindow();
                      
                        break;

                  /*  case ConsoleKey.S:

                        Console.Clear();
                        _employer.FilterCompany(_email, _password);
                        _employer.Render();
                        CompanyCreateDeleteJobAd();
                        break;*/
                }
                pressedChar = Console.ReadKey();
            }
        }

        public void CompanyNewJobAd()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("1 - IT; 2 - LOGISTIKA; 3 - FINANSAI; 4 - STATYBA; 5 - KLIENTU APTARNAVIMAS");

            Console.WriteLine("IVESKITE KATEGORIJOS ID IR PASPAUSKITE 'Enter'");
            _category = Console.ReadLine();

            while (_category == "")
            {
                Console.WriteLine("1 - IT; 2 - LOGISTIKA; 3 - FINANSAI; 4 - STATYBA; 5 - KLIENTU APTARNAVIMAS");
                Console.WriteLine("IVESKITE KATEGORIJOS ID IR PASPAUSKITE 'Enter'");
                _category = Console.ReadLine();
            }


            Console.WriteLine("IVESKITE DARBO POZICIJA IR PASPAUSKITE 'Enter'");
            _position = Console.ReadLine();

            while (_position == "")
            {
                Console.WriteLine("IVESKITE DARBO POZICIJA IR PASPAUSKITE 'Enter'");
                _position = Console.ReadLine();
            }


            Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter'");
            _city = Console.ReadLine();

            while (_city == "")
            {
                Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter'");
                _city = Console.ReadLine();
            }


            Console.WriteLine("IVESKITE DARBO APRASYMA IR PASPAUSKITE 'Enter' ir S");
            _jobdescription = Console.ReadLine();

            while (_jobdescription == "")
            {
                Console.WriteLine("IVESKITE DARBO APRASYMA IR PASPAUSKITE 'Enter' ir S");
                _jobdescription = Console.ReadLine();
            }
        }


        public void CompanyCreateDeleteJobAd()
        {
            ConsoleKeyInfo pressedChar = Console.ReadKey();

            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                    case ConsoleKey.C:

                        CompanyNewJobAd();

                        break;

                    case ConsoleKey.S:

                        Console.Clear();
                        _employer.CreateAdd(Convert.ToInt32(_employer.companyID[0]), Convert.ToInt32(_category), _position, _jobdescription, _city);
                        _employer.FilterCompany(_email, _password);
                        _employer.Render();

                        break;

                    case ConsoleKey.D:

                        Console.Clear();
                        Console.WriteLine("IVESKITE SKELBIMO ID IR PASPAUSKITE 'Enter' ir T");
                        _jobid = Console.ReadLine();

                        int value;
                        while (!int.TryParse(_jobid, out value))
                        {
                            Console.WriteLine("IVESKITE SKELBIMO ID IR PASPAUSKITE 'Enter' ir T");
                            _jobid = Console.ReadLine();
                        }

                        break;

                    case ConsoleKey.T:

                        Console.Clear();
                        _employer.DeleteAdd(Convert.ToInt32(_employer.companyID[0]), Convert.ToInt32(_jobid));
                        _employer.FilterCompany(_email, _password);
                        _employer.Render();
                        break;


                    case ConsoleKey.NumPad1:

                        Console.Clear();
                        //ShowMainMenu();
                        MainMenuReturn();
                        ShowWindow();
                       break;

                }
                pressedChar = Console.ReadKey();
            }
        }

        public int MainMenuReturn()
        {

            return _result = 0;
        }

        public int JobAdsReturn()
        {

            return _result = 1;
        }

        public int EmployerReturn()
        {

            return _result = 3;
            
        }


        public void JobAdsFilter()
        {
            Debug.WriteLine("JobAdsFilter");
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            while (pressedChar.Key != ConsoleKey.End)
            {
                switch (pressedChar.Key)
                {
                    case ConsoleKey.M:

                        Console.Clear();
                        Console.WriteLine("IVESKITE MIESTA IR PASPAUSKITE 'Enter ir S'");
                        _city = Console.ReadLine();

                        break;

                    case ConsoleKey.S:

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

                         Console.Clear();
                        _jobAds.FilterAllJobQuery(_city, _category, _company);
                        _jobAds.Render();
                        break;

                    case ConsoleKey.NumPad1:

                        Console.Clear();
                        MainMenuReturn();
                        ShowWindow();
                        //ShowMainMenu();
                        break;

                }


                pressedChar = Console.ReadKey();

            }

        }

    }
}
