using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Employees
    {
        //private string firstName;
        //private string lastName;

        public string FirstName { get; set; }
        
        //{
         //   get { return firstName; }
          //  set { firstName = value; }
      //  }
        public string LastName { get; set; }

        public Employees(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }

        public string ReturnFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
