using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DarboPaieska.Menu
{
    class Employer : Window
    {
        private TextLine _titleTextBlock;
        private TextLine _createAd;
        private TextLine _deleteAd;
        private TextLine _backToMainMenu;
        private TextLine _previewCV;
        private TextLine _return;

        public List<TextLine> SubMenu = new List<TextLine>();

        private TextBlock _errormessage;
        private TextBlock _errormessageperson;
        private TextBlock _companyName;


        public List<TextBlock> ads = new List<TextBlock>();
        public List<string> position = new List<string>();
        public List<string> city = new List<string>();
        public List<string> company = new List<string>();
        public List<string> companyID = new List<string>();
        public List<string> category = new List<string>();
        public List<string> ID = new List<string>();
        public List<int> CVcount = new List<int>();



        public List<TextBlock> Person = new List<TextBlock>();
        public List<string> PersonFirstName = new List<string>();
        public List<string> PersonLastName = new List<string>();
        public List<string> PersonEmail = new List<string>();
        public List<string> PersonPhone = new List<string>();
        public List<int> PersonAge = new List<int>();
        public List<string> PersonCvFile = new List<string>();

        private readonly string _connectionString;
        private int _index = 0;
        private int _personIndex = 0;
        private int j = 4;
        private int k = 0;


        public Employer() : base(0, 0, 120, 30, '*')
        {
            _connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            _titleTextBlock = new TextLine(20, 1, 20, "IMONES DARBO SKELBIMAI ");
            _createAd = new TextLine(45, 1, 20, "C - NAUJAS SKELBIMAS ");
            _deleteAd = new TextLine(70, 1, 20, "D - ISTRINTI ");
            _backToMainMenu = new TextLine(85, 1, 20, "1  - MENIU     ");
            _previewCV = new TextLine(100, 1, 10, "4 -  CV PERZIURA");
            _return = new TextLine(85, 1, 20, "ESC - GRIZTI");

            SubMenu.Add(_titleTextBlock);
            SubMenu.Add(_createAd);
            SubMenu.Add(_deleteAd);
            SubMenu.Add(_backToMainMenu);
            SubMenu.Add(_previewCV);

            _errormessage = new TextBlock(20, 1, 20, new List<String> { "TOKIO VARTOTOJO NERA ", "NORINT IS NAUJO PRISIJUNGTI PASPAUSKITE '1'" });
            _errormessageperson = new TextBlock(20, 1, 20, new List<String> { "DUOMENU NERA ", "NORINT GRIZTI PASPAUSKITE 'ESC'" });
        }

        public void PreviewCV(int filterAdId, int filterCompanyId)
        {
            Person.Clear();
            j = 4;
            k = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string sqlExpression = "select d.FirstName,d.LastName, d.Age,d.Phone,d.Email, d.CvFile " +
                    "from(select a.FirstName, a.LastName, a.Email, a.Phone, a.Age, b.CvFile,c.job_ad_Id  " +
                    "from jobseeker as a  inner join cv as b on a.Id=b.JobSeekerId inner join apply_cv as c on a.Id = c.jobseekerId) as d" +
                    " inner join job_ad as e on d.job_ad_Id = e.Id and e.CompanyId =" + "'" + filterCompanyId + "'" + "and e.Id =" + "'" + filterAdId + "'";

                using (SqlCommand comand = new SqlCommand(sqlExpression, con))

                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PersonFirstName.Add(reader.GetString(0));
                        PersonLastName.Add(reader.GetString(1));
                        PersonAge.Add(reader.GetInt32(2));
                        PersonPhone.Add(reader.GetString(3));
                        PersonEmail.Add(reader.GetString(4));
                        PersonCvFile.Add(reader.GetString(5));


                        if (2 + 7 * k >= 26)
                        {
                            k = 0;
                            j += 45;
                        }

                        Person.Add(new TextBlock(j, 2 + 7 * k, 30, new List<String> { "Vardas: " + PersonFirstName[_personIndex], "Pavarde: " + PersonLastName[_personIndex], "Amzius: " + PersonAge[_personIndex], "Telefonas: " + PersonPhone[_personIndex], "El.pastas: " + PersonEmail[_personIndex], "CV: " + PersonCvFile[_personIndex] }));
                        _personIndex++;
                        k++;
                    }


                }
            }

        }

        public void FilterCompany(string filterEmail, string filterPassword)
        {
            ads.Clear();
            j = 4;
            k = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string sqlExpression = "select top 15  job_ad.position, job_ad.City,company.CompName, " +
                    "category.CategName,job_ad.Id, company.Id, isnull((select count(apply_cv.jobseekerId) " +
                    " from apply_cv where job_ad.Id = apply_cv.job_ad_Id group by apply_cv.job_ad_id ),0) as cvcount " +
                    "from job_ad inner join company on  job_ad.CompanyId = company.Id inner join category on job_ad.CategoryId = category.Id " +
                    "where company.CompEmail =" + "'" + filterEmail + "'" + " and company.CompPassword =" + "'" + filterPassword + "'";

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
                        CVcount.Add(reader.GetInt32(6));

                        if (5 + 5 * k >= 26)
                        {
                            k = 0;
                            j += 40;
                        }

                        ads.Add(new TextBlock(j, 5 + 5 * k, 30, new List<String> { "Skelbimo ID: " + ID[_index] + "         Siunte CV: " + CVcount[_index], position[_index], "Miestas: " + city[_index], "Darbo sritis: " + category[_index] }));
                        _index++;
                        k++;
                    }
                    if (company.Count > 0)
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
                String query = "DELETE FROM job_ad WHERE Id = @Id AND CompanyId = @CompanyId";

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
            Console.Clear();
            base.Render();
            j = 4;
            k = 0;
            if (ads.Count > 0)
            {
                _companyName.Render();
                base.Render();

                for (int i = 0; i < SubMenu.Count; i++)
                {
                    SubMenu[i].Render();
                }

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

        public void PersonRender()
        {
           Console.Clear();
            base.Render();
            j = 4;
            k = 0;
            if (Person.Count > 0)
            {
                _return.Render();

                for (int i = 0; i < Person.Count; i++)
                {
                    Person[i].Render();
                }

            }

            else
            {
                _errormessageperson.Render();
            }

                                                                             
        }


    }
}
