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

        public List<TextBlock> ads = new List<TextBlock>();
        public List<string> position = new List<string>();
        public List<string> description = new List<string>();
        private int _index = 0;
        private int j = 0;
        private int k = 0;
        public JobAds() : base(0, 0, 120, 30, '*')
        {

            _titleTextBlock = new TextBlock(50, 2, 20, new List<String> { "DARBO SKELBIMAI " });



        }

        public override void Render()
        {

            base.Render();
            _titleTextBlock.Render();

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand comand = new SqlCommand("Select Top 5 position, JobDescription from job_ad  ", con))
                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        position.Add(reader.GetString(0));
                        description.Add(reader.GetString(1));
                        
                        ads.Add(new TextBlock(0, 4 + 5 * _index, 30, new List<String> { position[_index], description[_index] }));
                        _index++;
                       
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
