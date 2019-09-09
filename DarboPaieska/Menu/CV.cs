using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DarboPaieska.Menu
{
    class CV : Window
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private int _age;
        private string _password;
        private string _cvFile;
        private string _description;
        public List<string> PersonInfo = new List<string>();
        public List<TextBlock> Person = new List<TextBlock>();

        private readonly string _connectionString;

        public CV() : base(0, 0, 120, 30, '*')
        {
            _connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
        }


        public void PersonCV(string firstName, string lastName, string email, string phone,  string password, int age, string cvfile,string description)
        {

          PersonInfo.Add(firstName);
          PersonInfo.Add(lastName);
          PersonInfo.Add(email);
          PersonInfo.Add(phone);
          PersonInfo.Add(password);
          PersonInfo.Add(Convert.ToString(age));

          Person.Add(new TextBlock(3, 5, 30, new List<String> { "Vardas: " + firstName, "Pavarde: " + lastName, "Email: " + email, "Telefonas: " + phone, "Slaptazodis: " + password, "Amzius: " + age }));

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.jobseeker (FirstName,LastName, Email,Phone,JsPassword,Age) VALUES (@FirstName,@LastName,@Email,@Phone, @JsPassword,@Age)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@JsPassword", password);
                    command.Parameters.AddWithValue("@Age", age);
                   

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public override void Render()
        {
            Console.Clear();

            base.Render();

        //    Person.Render();

            foreach (string str in PersonInfo)
            {
                Console.WriteLine(str);
            }

        }
    }
}
