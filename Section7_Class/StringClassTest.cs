using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Section7_Class
{
    [TestClass]
    public class StringClassTest
    {
        [TestMethod]
        public void Using_String_Class()
        {

            string str = "Last night I dreamt of San";
            Console.WriteLine(str);
            string substr = str.Substring(23);
            Console.WriteLine(substr);

        }
    }
}
