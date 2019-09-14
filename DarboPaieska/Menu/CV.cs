using DarboPaieska.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DarboPaieska.Menu
{
    class CV : Window
    {
              
        public List<TextBlock> Person = new List<TextBlock>();

        private readonly string _connectionString;
        private TextLine _backToMainMenu;

        public CV() : base(0, 0, 120, 30, '*')
        {
            _connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
            _backToMainMenu = new TextLine(85, 1, 20, "1  - MENIU     ");
        }


        public void PersonCV(string firstName, string lastName, string email, string phone,  string password, int age, string cvfile,string description)
        {

        

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
            _backToMainMenu.Render();
            Person[0].Render();

             
        }
    }
}
