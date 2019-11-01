using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class ReceiptTest
    {
        [TestMethod]
        public void ReceiptTestMethod1()
        {
            Receipt receipt = new Receipt(1, "2019.08.12", 5, "Alisa Golaves", "Comando street 15-2", "85633333", 6, "triofaf", 5.28, 9);
            //Console.WriteLine(receipt);
            Assert.AreEqual(1, receipt.ReceiptNumber);
        }
        [TestMethod]
        public void ReceiptTestMethod2()
        {
            Receipt receipt = new Receipt(-8, "2019.08.12", 5, "Zosia Golaves", "Comando street 15-2", "85633333", -6, "triofaf", 5.28, 9);
            //Console.WriteLine(receipt);
            Assert.AreEqual(0, receipt.ItemNumber);
        }
    }
}
