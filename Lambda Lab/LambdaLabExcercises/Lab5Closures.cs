using System;
using NUnit.Framework;

namespace LambdaLabExcercises
{
    [TestFixture]
    public class Lab5Closures
    {
        [Test]
        public void PlainAnonymousFunction()
        {
            Func<string, string> hello = who => "Hello " + who;

            Assert.AreEqual("Hello NashDotNet", hello("NashDotNet"));
        }

        [Test]
        public void ExampleOfAClosure()
        {
            string who = "NashDotNet";

            // Notice we aren't passing "who" as a parameter

            Func<string> hello = () => "Hello " + who;

            Assert.AreEqual("Hello NashDotNet", ClosureProof.RunIt(hello));
        }
    }

    public static class ClosureProof
    {
        public static string RunIt(Func<string> theClosure)
        {
            return theClosure();
        }
    }
}