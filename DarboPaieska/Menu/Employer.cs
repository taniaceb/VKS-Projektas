using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DarboPaieska.Menu
{
    class Employer : Window
    {
        private TextBlock _titleTextBlock;
        private TextBlock _companyName;
        private TextBlock _createAd;
        private TextBlock _deleteAd;
        private TextBlock _errormessage;
        private TextBlock _backToMainMenu;

        public List<TextBlock> ads = new List<TextBlock>();
        public List<string> position = new List<string>();
        public List<string> city = new List<string>();
        public List<string> company = new List<string>();
        public List<string> companyID = new List<string>();
        public List<string> category = new List<string>();
        public List<string> ID = new List<string>();
        private readonly string _connectionString;
        private int _index = 0;
        private int j = 4;
        private int k = 0;
        

        public Employer() : base(0, 0, 120, 30, '*')
        {
            _connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            _titleTextBlock = new TextBlock(20, 1, 20, new List<String> { "IMONES DARBO SKELBIMAI " });
            _createAd = new TextBlock(80, 1, 20, new List<String> { "C - NAUJAS SKELBIMAS " });
            _deleteAd = new TextBlock(80, 3, 20, new List<String> { "D - ISTRINTI " });
            _backToMainMenu = new TextBlock(80, 5, 20, new List<String> { "1 - MENIU " });
            _errormessage = new TextBlock(20, 1, 20, new List<String> { "TOKIO VARTOTOJO NERA ", "NORINT IS NAUJO PRISIJUNGTI PASPAUSKITE '1'" });

        }

        public void FilterCompany(string filterEmail,string filterPassword)
        {
            ads.Clear();
            j = 4;
            k = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string sqlExpression = "select top 15  job_ad.position, job_ad.City," +
                    "company.CompName, category.CategName,job_ad.Id,company.Id from job_ad " +
                    "  inner join company on  job_ad.CompanyId = company.Id " +
                    "inner join category on job_ad.CategoryId = category.Id where company.CompEmail =" + "'" + filterEmail + "'" + " and company.CompPassword =" + "'" + filterPassword + "'"; 

                using (SqlCommand comand = new SqlCommand(sqlExpression, con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        position.Add(reader.GetString(0));
                        city.Add(reader.GetString(1));
                        company.Add(reader.GetString(2));
                        category.Add(reader.GetString(3));
                        ID.Add(reader.GetInt32(4).ToString());
                        companyID.Add(reader.GetInt32(5).ToString());

                        

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { "Skelbimo ID: " + ID[_index],position[_index], "Miestas: " + city[_index],  "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                    if (company.Count>0)
                    {
                        _companyName = new TextBlock(5, 1, 20, new List<String> { company[0] });
                    }
                    
                }
            }
        }

        public void CreateAdd(int compId, int categId, string posit, string jobdescr, string city)
        {

            

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.job_ad (CompanyId,CategoryId, Position,JobDescription,City) VALUES (@companyId,@categoryId,@position,@jobdescription, @city)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@companyId", compId);
                    command.Parameters.AddWithValue("@categoryId", categId);
                    command.Parameters.AddWithValue("@position", posit);
                    command.Parameters.AddWithValue("@jobdescription", jobdescr);
                    command.Parameters.AddWithValue("@city", city);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public void DeleteAdd(int compId, int jobId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query =  "DELETE FROM job_ad WHERE Id = @Id AND CompanyId = @CompanyId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", compId);
                    command.Parameters.AddWithValue("@Id", jobId);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error deleting data from Database!");
                }
            }
        }


        public override void Render()
        {

            base.Render();
          
            if (ads.Count>0)
            {
                _companyName.Render();
                _titleTextBlock.Render();
                _createAd.Render();
                _deleteAd.Render();
                _backToMainMenu.Render();

                for (int i = 0; i < ads.Count; i++)
                {
                    ads[i].Render();
                }

            }
            else
            {
                _errormessage.Render();
            }
            

                       
        }

    }
}
