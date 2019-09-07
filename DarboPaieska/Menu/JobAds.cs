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
        private TextBlock _searchAll;
        private TextBlock _backToMainMenu;
        private TextBlock _sendCV;

        public List<TextBlock> ads = new List<TextBlock>();
        public List<int> AdId = new List<int>();
        public List<string> position = new List<string>();
        public List<string> city = new List<string>();
        public List<string> company = new List<string>();
        public List<string> category = new List<string>();
        private int _index = 0;
        private int j = 4;
        private int k = 0;

        public JobAds() : base(0, 0, 120, 30, '*')
        {

            _titleTextBlock = new TextBlock(3, 1, 20, new List<String> { "DARBO SKELBIMAI " });
            _searchCity = new TextBlock(20, 1, 20, new List<String> { "FILTRAS:Miestas ", "Paspausti M     " });
            _searchAll = new TextBlock(40, 1, 20, new List<String> { "FILTRAS:Miestas, Darbo sritis, Imone  ", "Paspausti F     " });
            _backToMainMenu = new TextBlock(80, 1, 20, new List<String> { "MENIU       ", "Paspausti 1     " });
            _sendCV = new TextBlock(100, 1, 20, new List<String> { "Siusti savo CV   ", "Paspausti 5     " });
        }

        public void SelectJobQuery()
        {

            ads.Clear();
            j = 4;
            k = 0;
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand comand = new SqlCommand("select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad, " +
                    "company, category where job_ad.CompanyId = company.Id " +
                    "and job_ad.CategoryId = category.Id  ", con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AdId.Add(reader.GetInt32(0));
                        position.Add(reader.GetString(1));
                        city.Add(reader.GetString(2));
                        company.Add(reader.GetString(3));
                        category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { position[_index] + "  ID- " + AdId[_index], "Miestas: " + city[_index], "Imone: " + company[_index], "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                }
            }
        }


        public void FilterCityJobQuery(string filterCity)
        {
            ads.Clear();
            j = 4;
            k = 0;

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sqlExpression = "select top 15 job_ad.Id, job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad " +
                    "  inner join company on  job_ad.CompanyId = company.Id " +
                    "inner join category on job_ad.CategoryId = category.Id where job_ad.City =" + "'" + filterCity + "'";

                using (SqlCommand comand = new SqlCommand(sqlExpression, con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AdId.Add(reader.GetInt32(0));
                        position.Add(reader.GetString(1));
                        city.Add(reader.GetString(2));
                        company.Add(reader.GetString(3));
                        category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { position[_index] + "  ID- " + AdId[_index], "Miestas: " + city[_index], "Imone: " + company[_index], "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                }
            }
        }

        public void FilterAllJobQuery(string filterCity, string filterCategory, string filterCompany)
        {
            ads.Clear();
            AdId.Clear();
            position.Clear();
            city.Clear();
            company.Clear();
            category.Clear();
            j = 4;
            k = 0;
            _index = 0;
            string sqlExpression;

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (filterCity == "" & filterCategory == "" & filterCompany == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad, " +
                    "company, category where job_ad.CompanyId = company.Id " +
                    "and job_ad.CategoryId = category.Id  ";

                }
                else if (filterCategory == "" & filterCompany == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad " +
                    "  inner join company on  job_ad.CompanyId = company.Id " +
                    "inner join category on job_ad.CategoryId = category.Id where job_ad.City =" + "'" + filterCity + "'";


                }
                else if (filterCity == "" & filterCompany == "")
                {

                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad " +
                    "  inner join company on  job_ad.CompanyId = company.Id " +
                    "inner join category on job_ad.CategoryId = category.Id where category.CategName =" + "'" + filterCategory + "'";

                }
                else if (filterCity == "" & filterCategory == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName from job_ad " +
                    "  inner join company on  job_ad.CompanyId = company.Id " +
                    "inner join category on job_ad.CategoryId = category.Id where company.CompName =" + "'" + filterCompany + "'";

                }
                else if (filterCity == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                   "company.CompName, category.CategName from job_ad " +
                   "  inner join company on  job_ad.CompanyId = company.Id " +
                   "inner join category on job_ad.CategoryId = category.Id " +
                   "where category.CategName = " + "'" + filterCategory + "'" + " and company.CompName =" + "'" + filterCompany + "'";


                }
                else if (filterCategory == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                   "company.CompName, category.CategName from job_ad " +
                   "  inner join company on  job_ad.CompanyId = company.Id " +
                   "inner join category on job_ad.CategoryId = category.Id " +
                   "where job_ad.City = " + "'" + filterCity + "'" + " and company.CompName =" + "'" + filterCompany + "'";


                }
                else if (filterCompany == "")
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                   "company.CompName, category.CategName from job_ad " +
                   "  inner join company on  job_ad.CompanyId = company.Id " +
                   "inner join category on job_ad.CategoryId = category.Id " +
                   "where job_ad.City = " + "'" + filterCity + "'" + " and category.CategName =" + "'" + filterCategory + "'";


                }
                else
                {
                    sqlExpression = "select top 15 job_ad.Id,job_ad.position, job_ad.City," +
                  "company.CompName, category.CategName from job_ad " +
                  "  inner join company on  job_ad.CompanyId = company.Id " +
                  "inner join category on job_ad.CategoryId = category.Id " +
                  "where job_ad.City = " + "'" + filterCity + "'" + " and category.CategName =" + "'" + filterCategory + "'" + " and company.CompName =" + "'" + filterCompany + "'";

                }

                using (SqlCommand comand = new SqlCommand(sqlExpression, con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AdId.Add(reader.GetInt32(0));
                        position.Add(reader.GetString(1));
                        city.Add(reader.GetString(2));
                        company.Add(reader.GetString(3));
                        category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { position[_index] + "  ID- " + AdId[_index], "Miestas: " + city[_index], "Imone: " + company[_index], "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                }
            }
        }


        public override void Render()
        {
            Console.Clear();
            _index = 0;
            base.Render();
            _titleTextBlock.Render();
            _searchCity.Render();
            _searchAll.Render();
            _backToMainMenu.Render();
            _sendCV.Render();

            if(ads.Count>0)
            {
                for (int i = 0; i < ads.Count; i++)
                {
                    ads[i].Render();
                }
            }
            
                                 
        }
    }
}
