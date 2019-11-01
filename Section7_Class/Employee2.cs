using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7_Class
{
    class Employee2
    {
        //constructor
        public Employee2(int id)
        {
            EmployeeID = id;
        }

        public Employee2(string name, int id, string title)
        {
            Name = name;
            EmployeeID = id;
            JobTitle = title;
        }

        //properties
        public string Name { get;  set; }
        public int EmployeeID { get; set; }
        public string JobTitle { get; set; }

        //method
        public string JobLocation()
        {
            if(JobTitle=="Manager")
            {
                return "Boston";
            }

            else if(JobTitle=="Staff")
            {
                return "Chicago";
            }
            return "New York";
        }

        public override string ToString()
        {
            return EmployeeID + " " + Name + "Job Title: " + JobTitle;
        }

    }


}
