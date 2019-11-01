using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void Class_Car_Color_Set()
        {
            //arrange
            Car myCar = new Car("Red", 2, true);


            //act

            //assert
            StringAssert.Equals(myCar.Color, "Red");
        }

        [TestMethod]
        public void Call_Acceleration_Method()
        {
            Car myCar = new Car("Red", 2, true);
            myCar.Accelerate();

        }

        [TestMethod]
        public void Call_FamilyCar_Method()
        {
            Car myCar = new Car("Red", 4, true);
            bool carType = myCar.FamilyCar();

            //assert
            if(carType==true)
            {
                Assert.IsTrue(carType == true);
            }
            else 
            {
                Assert.Fail();
            }
        }


    }
}
