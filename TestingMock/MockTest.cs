using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingMock.Logic;
using Moq;

namespace TestingMock
{
    [TestClass]
    public class MockTest
    {
        static Bar bar;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            var mock = new Mock<IFoo>();
            mock.Setup(x => x.DoSomething(It.IsAny<string>()))
                .Returns(true);

            mock.Setup(x => x.StringMethod(It.Is<int>(y => y % 2 == 0)))
                .Returns("Even number is passed as a parameter");

            mock.Setup(x => x.StringMethod(It.Is<int>(y => y % 2 != 0)))
                .Returns("Odd number is passed as a parameter");

            mock.SetupProperty(x => x.Name, "John");

            bar = new Bar(mock.Object);
        }

        [TestMethod]
        public void DoSomething()
        {
            Assert.IsTrue(bar.DoSomething("Whatever string is passed. True will be returned anyway"));
        }

        [TestMethod]
        public void StringMethodEvenNumberIsPassed()
        {
            Assert.AreEqual(bar.StringMethod(2), "Even number is passed as a parameter");
        }

        [TestMethod]
        public void StringMethodEvenOddNumberIsPassed()
        {
            Assert.AreEqual(bar.StringMethod(3), "Odd number is passed as a parameter");
        }

        [TestMethod]
        public void MockPropertyTest()
        {
            Assert.AreEqual(bar.Name, "John");
        }
    }
}
