using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7_Class
{
    class Employees
    {
        private int employeeNumber;
        private string firstName;
        private string lastName;
        private string dateOfHire;
        private string jobDescription;
        private string department;
        private double monthlySalary;


        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string DateOfHire
        {
            get { return dateOfHire; }
            set { dateOfHire = value; }
        }
        public string JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public double MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }


        public Employees(int empNumber, string firName, string lasName, string date, string description, string depart, double salary)
        {
            EmployeeNumber = empNumber;
            FirstName = firName;
            LastName = lasName;
            DateOfHire = date;
            JobDescription = description;
            Department = depart;
            MonthlySalary = salary;
        }

        public string ReturnFullName()
        {
            //Console.WriteLine(FirstName + " " + LastName);
            //string fullName = FirstName + " " + LastName;
            return FirstName + " " + LastName;
        }

        public string ReturnSortName()
        {
            //Console.WriteLine(FirstName + " " + LastName);
            //string sortName = LastName + ", " + FirstName;
            return LastName + ", " + FirstName;
        }

    }
}
