using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DarboPaieska.Menu
{



    class JobAds : Window
    {


        private TextBlock _titleTextBlock;
        private TextBlock _searchCity;

        public List<TextBlock> ads = new List<TextBlock>();
        public List<string> position = new List<string>();
        public List<string> city = new List<string>();
        public List<string> company = new List<string>();
        public List<string> category = new List<string>();
        private int _index = 0;
        private int j = 4;
        private int k = 0;
        public JobAds() : base(0, 0, 120, 30, '*')
        {

            _titleTextBlock = new TextBlock(20, 1, 20, new List<String> { "DARBO SKELBIMAI " });
            _searchCity = new TextBlock(50, 1, 20, new List<String> { "Filtras:Miestas ", "Paspausti M     " });


        }

        public override void Render()
        {

            base.Render();
            _titleTextBlock.Render();
            _searchCity.Render();

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand comand = new SqlCommand("select job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad, " +
                    "company, category where job_ad.CompanyId = company.Id " +
                    "and job_ad.CategoryId = category.Id  ", con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        position.Add(reader.GetString(0));
                        city.Add(reader.GetString(1));
                        company.Add(reader.GetString(2));
                        category.Add(reader.GetString(3));

                        if(5 + 5 * k>=26)
                        {
                           k = 0;
                           j += 40;
                        }
                        
                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { position[_index], "Miestas: " + city[_index], "Imone: " + company[_index], "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                }

            }

            for (int i = 0; i < ads.Count; i++)
            {
                ads[i].Render();
            }


            /*while (true)
            {
                for (int i = 0; i < MenuItem.Count; i++)
                {
                    if (i == _index)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        MenuItem[i].Render();
                    }
                }
            }*/

            //Console.SetCursorPosition(0, 0);
        }
    }
}
