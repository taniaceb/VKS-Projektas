using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class EmployeersTest
    {
        [TestMethod]
        public void EmployerTest1()
        {
            Employees employee1 = new Employees(1, "Alnas", "Kalnas", "20181014", "Tester", "IT", 1250.50);
            string fullName = employee1.ReturnFullName();
            StringAssert.Equals(fullName, "Alnas Kalnas");
        }
    }
}
