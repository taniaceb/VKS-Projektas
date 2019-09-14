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

        public List<TextBlock> Ads = new List<TextBlock>();
        public List<int> AdId = new List<int>();
        public List<string> Position = new List<string>();
        public List<string> City = new List<string>();
        public List<string> Company = new List<string>();
        public List<string> Category = new List<string>();
        public int PersonId;
        private int _index = 0;
        private int j = 4;
        private int k = 0;
        private readonly string _connectionString;

        public JobAds() : base(0, 0, 120, 30, '*')
        {
            _connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            _titleTextBlock = new TextBlock(3, 1, 20, new List<String> { "DARBO SKELBIMAI " });
            _searchCity = new TextBlock(20, 1, 20, new List<String> { "FILTRAS:Miestas ", "Paspausti M     " });
            _searchAll = new TextBlock(40, 1, 20, new List<String> { "FILTRAS:Miestas, Darbo sritis, Imone  ", "Paspausti F     " });
            _backToMainMenu = new TextBlock(80, 1, 20, new List<String> { "MENIU       ", "Paspausti  1    " });
            _sendCV = new TextBlock(100, 1, 20, new List<String> { "Siusti savo CV   ", "Paspausti  5    " });
        }

        public void SelectPerson(string filterEmail, string filterPassword)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand comand = new SqlCommand("select Id from jobseeker " +
                    "where Email =" + "'" + filterEmail + "'" + "and JsPassword =" + "'" + filterPassword + "'", con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PersonId = reader.GetInt32(0);


                    }
                }
            }

        }

        public void  ApplyCV(int adId, int personId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.apply_cv (job_ad_Id, jobseekerId) VALUES (@job_ad_Id,@jobseekerId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@job_ad_Id", adId);
                    command.Parameters.AddWithValue("@jobseekerId", personId);
                    
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
        public void SelectJobQuery()
        {

            Ads.Clear();
            j = 4;
            k = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
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
                        Position.Add(reader.GetString(1));
                        City.Add(reader.GetString(2));
                        Company.Add(reader.GetString(3));
                        Category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        Ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { Position[_index] + "  ID- " + AdId[_index], "Miestas: " + City[_index], "Imone: " + Company[_index], "Darbo sritis: " + Category[_index] }));
                        _index++;
                        k++;
                    }
                }
            }
        }


        public void FilterCityJobQuery(string filterCity)
        {
            Ads.Clear();
            j = 4;
            k = 0;


            using (SqlConnection con = new SqlConnection(_connectionString))
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
                        Position.Add(reader.GetString(1));
                        City.Add(reader.GetString(2));
                        Company.Add(reader.GetString(3));
                        Category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        Ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { Position[_index] + "  ID- " + AdId[_index], "Miestas: " + City[_index], "Imone: " + Company[_index], "Darbo sritis: " + Category[_index] }));
                        _index++;
                        k++;
                    }
                }
            }
        }

        public void FilterAllJobQuery(string filterCity, string filterCategory, string filterCompany)
        {
            Ads.Clear();
            AdId.Clear();
            Position.Clear();
            City.Clear();
            Company.Clear();
            Category.Clear();
            j = 4;
            k = 0;
            _index = 0;
            string sqlExpression;


            using (SqlConnection con = new SqlConnection(_connectionString))
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
                        Position.Add(reader.GetString(1));
                        City.Add(reader.GetString(2));
                        Company.Add(reader.GetString(3));
                        Category.Add(reader.GetString(4));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        Ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { Position[_index] + "  ID- " + AdId[_index], "Miestas: " + City[_index], "Imone: " + Company[_index], "Darbo sritis: " + Category[_index] }));
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

            if (Ads.Count > 0)
            {
                for (int i = 0; i < Ads.Count; i++)
                {
                    Ads[i].Render();
                }
            }


        }
    }
}
