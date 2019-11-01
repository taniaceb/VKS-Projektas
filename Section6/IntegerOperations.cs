using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Section6
{
    [TestClass]
    public class IntegerOperations
    {
        static int number1;
        static int number2;

        [ClassInitialize()]

        public static void IntegerInitialize(TestContext testContext)
        {
            number1 = 10;
            number2 = 5;
        }

        [TestMethod]
        public void Test_Addition()
        {
            int sum = number1 + number2;
            Console.WriteLine(sum);
            Assert.AreEqual(sum, 15);
        }

        [TestMethod]
        public void Test_Subtraction()
        {
        }
    }
}
