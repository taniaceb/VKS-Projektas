using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class Employee2Test
    {
        [TestMethod]
        public void Tes_Employee_ID_Set()
        {
            Employee2 employee1 = new Employee2(123);
            employee1.JobTitle = "Manager";
            string jobLocation = employee1.JobLocation();

            StringAssert.Equals(jobLocation, "Boston");
        }
        [TestMethod]

        public void To_String_Test()
        {
            Employee2 employee1 = new Employee2("Sara Burke ", 12345, "Manager");
            Console.WriteLine(employee1);
        }
    }
}
