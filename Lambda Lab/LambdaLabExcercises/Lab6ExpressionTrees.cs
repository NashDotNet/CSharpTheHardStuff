using System;
using System.Linq;
using System.Linq.Expressions;
using LambdaLabExcercises.Data;
using NUnit.Framework;

namespace LambdaLabExcercises
{
  

    [TestFixture]
    public class Lab6ExpressionTrees
    {
        [Test]
        public void FirstExpressionTree()
        {
            Expression<Func<int, int, int>> add = (x, y) => x + y;

            Console.WriteLine(add);
            
            var addFiveAndNine = add.Compile()(5, 9);

            Assert.AreEqual(14, addFiveAndNine);
        }


        [Test]
        public void MemberInitFun()
        {
            Expression<Func<Employee>> typeInitializer = () => new Employee
                                                                   {
                                                                       FirstName = "Bryan",
                                                                       LastName = "Hunter"
                                                                   };

            var initExpression = typeInitializer.Body as MemberInitExpression;

            if (initExpression == null) return;

            var bindings = initExpression.Bindings;

            var dict = bindings.ToDictionary(x => x.Member.Name,
                                             x => ((ConstantExpression) 
                                                 ((MemberAssignment) x)
                                                 .Expression).Value);

        }
    }
}