using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section6_1
{
    [TestClass]
    public class EqualityAndRelationship
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
        public void Number1IsEqualNumber2()
        {
            if (number1 == number2)
            {
                Assert.IsTrue(number1 == number2);
            }
            Assert.IsFalse(number1 == number2);
        }
        
        [TestMethod]
        public void Number1IsNotEqualNumber2()
        {
            if(number1!=number2)
            {
                Assert.IsTrue(number1 != number2);
            }
        }

        [TestMethod]
        public void Number1_Is_Greater_Than_Number2()
        {
            if (number1 > number2)
            {
                Assert.IsTrue(number1 > number2);
            }
        }

        [TestMethod]
        public void Number1_Is_Greater_Than_Or_Equal_Number2()
        {
            if (number1 >= number2)
            {
                Assert.IsTrue(number1 >= number2);
            }
        }
    }
}
