using System;
using LemonWayTestApplication.Services.Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonWayTestApplication.Tests
{
    [TestClass]
    public class FibonacciServiceTest
    {
        [TestMethod]
        public void Fibonacci_Equals_8()
        {
            var fibonacciService = new FibonacciService();
            Assert.AreEqual(8, fibonacciService.Fibonacci(6));
        }
        [TestMethod]
        public void Fibonacci_N_Equals_1()
        {
            var fibonacciService = new FibonacciService();
            Assert.AreEqual(1, fibonacciService.Fibonacci(1));
        }
        [TestMethod]
        public void Fibonacci_N_Equals_0()
        {
            var fibonacciService = new FibonacciService();
            Assert.AreEqual(-1, fibonacciService.Fibonacci(0));
        }
        [TestMethod]
        public void Fibonacci_N_LowerThan_0()
        {
            var fibonacciService = new FibonacciService();
            Assert.AreEqual(-1, fibonacciService.Fibonacci(-1));
        }
        [TestMethod]
        public void Fibonacci_N_BiggerThan_100()
        {
            var fibonacciService = new FibonacciService();
            Assert.AreEqual(-1, fibonacciService.Fibonacci(101));
        }
    }
}
