using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class TripTest
    {
        [TestMethod]
        public void TripMethod1()
        {
            Trip trip = new Trip(100, 45, 40.22, 2.75);
            Console.WriteLine(trip);

        }
    }
}
