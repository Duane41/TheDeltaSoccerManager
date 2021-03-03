using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoccerManagerUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "Hello World!";
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var controller = new ClubsController();
                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
