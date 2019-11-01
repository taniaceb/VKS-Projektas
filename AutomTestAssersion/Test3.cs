using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace AutomTestAssersion
{


    [TestClass]
    [TestCategory("Part3")]
    public class Test3
    {
        private int a;
       
        public TestContext TestContext { get; set; }

        //Galima taip
      //  {

       //     get { return _testContext; }

       //     set { _testContext = value; }

      //  }


       

        private static TestContext _testContext;
       

        [TestInitialize]
        public void RunBeforeEveryTest()
        {
           
            a = 1;
        }

        [TestCleanup]
        public void RunAfterEveryTestMethod()
        {
            Trace.WriteLine("RunAfterEveryTestMethod will execute after every single test method in a class");
        }

        [ClassInitialize]
        public static void RunAfterAllOfTheTestMethodsStarted(TestContext testContext)
        {
            _testContext = testContext;
            
            Trace.WriteLine("I will run one time before all the tests in the class started");
        }

        [ClassCleanup]
        public static void RunAfterEveryTestClass()
        {
            Trace.WriteLine("I will run one time after all the tests in the class finished");
        }

        [TestMethod]

        public void TestMethod1()
        {
            //var a = 1;
            var b = 2;
            Assert.AreEqual(3, a + b);
          
          //  Trace.WriteLine(TestContext.TestName);
            Trace.WriteLine(TestContext.CurrentTestOutcome);
        }

        [TestMethod]

        public void TestMethod2()
        {
            // var a = 1;
            Trace.WriteLine(TestContext.TestName);
            Assert.IsTrue(a == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]

        public void TestMethod3()
        {
            //var a = 1;
            Trace.WriteLine(TestContext.TestName);
            Assert.AreNotEqual(1, a);
        }
    }
}
