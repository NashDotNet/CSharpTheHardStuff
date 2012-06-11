using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LambdaLabExcercises
{
    [TestFixture]
    public class Lab1Delegates
    {
        // A delegate is a type that references a method. Once a delegate is assigned a method, 
        // it behaves exactly like that method. The delegate method can be used like any other 
        // method, with parameters and a return value, as in this example:

        // C#
        // public delegate int PerformCalculation(int x, int y);

        // Any method that matches the delegate's signature, which consists of the return type 
        // and parameters, can be assigned to the delegate. This makes is possible to 
        // programmatically change method calls, and also plug new code into existing classes. 
        // As long as you know the delegate's signature, you can assign your own delegated method.

        // This ability to refer to a method as a parameter makes delegates ideal for defining 
        // callback methods. For example, a sort algorithm could be passed a reference to the 
        // method that compares two objects. Separating the comparison code allows the algorithm 
        // to be written in a more general way.


        delegate int AddFiveDelegate(int i);

        [Test]
        public void Delegate_AddFive()
         {
             // As an an anonymous method
             AddFiveDelegate addFiveDelegate1 = delegate(int i) { return AddFive(i); };
             Assert.AreEqual(8, addFiveDelegate1(3));

             // As a method group
             AddFiveDelegate myAddFiveDelegate2 = AddFive;
             Assert.AreEqual(8, myAddFiveDelegate2(3));

             // As a lambda expression
             AddFiveDelegate myAddFiveDelegate3 = x => x + 5;
             Assert.AreEqual(8, myAddFiveDelegate3(3));
         }

        private static int AddFive(int i)
        {
            return i + 5;
        }
    }
}
