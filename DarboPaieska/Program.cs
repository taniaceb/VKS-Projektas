using DarboPaieska.Menu;
using System;
using System.Data.SqlClient;

namespace DarboPaieska
{
    class Program
    {
        static void Main(string[] args)
        {

            /*  string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Job_Search";
              using (SqlConnection con = new SqlConnection(connectionString))
              {
                  con.Open();
                  using (SqlCommand comand = new SqlCommand("Select id,position, jobDescription from job_ad ", con))
                  using (SqlDataReader reader = comand.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          Console.WriteLine("{0},{1},{2}", reader.GetInt32(0), reader.GetString(1),reader.GetString(2));
                      }
                  }


           }*/



            // Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            JobAds jobAds = new JobAds();
            // MainMenu mainMenu = new MainMenu();

            // mainMenu.Render();
            jobAds.Render();
            Console.ReadKey();
           

        }
    }
}
