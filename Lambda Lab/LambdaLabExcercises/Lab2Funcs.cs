using System;
using NUnit.Framework;

namespace LambdaLabExcercises
{
    [TestFixture]
    public class Lab2Funcs
    {
        [Test]
        public void FirstFunc_AddFive()
        {
            // A lambda expression is an anonymous function that can contain expressions and statements, 
            // and can be used to create delegates or expression tree types.
            
            // Func
            Func<int, int> addFive = null;

            addFive = delegate(int x) { return x + 5; };  

            // Lambda expression
            addFive = (int x) => { return x + 5; };
            addFive = (int x) => x + 5;
            addFive = (x) => x + 5;
            addFive = x => x + 5;

            Assert.AreEqual(5, addFive(0));
            Assert.AreEqual(25, addFive(20));
        }

        [Test]
        public void Calculator()
        {
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> subtract = (x, y) => x - y;
            Func<int, int, int> multiply = (x, y) => x * y;

            var calc = add;
            Assert.AreEqual(6, calc(4, 2));

            calc = subtract;
            Assert.AreEqual(2, calc(4, 2));

            calc = multiply;
            Assert.AreEqual(8, calc(4, 2));

        }
    }
}