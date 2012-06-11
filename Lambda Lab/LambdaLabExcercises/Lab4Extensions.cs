using System;
using System.Linq;
using LambdaLabExcercises.Data;
using NUnit.Framework;

namespace LambdaLabExcercises
{
    [TestFixture]
    public class Lab4Extensions
    {

        [Test]
        public void PartitionItems()
        {
            var tenYearsAgo = DateTime.Now.AddYears(-10);

            var employees = Employees.GetAll();

            var oldTimersAndNoobs = employees.Partition(x => x.HireDate <= tenYearsAgo);
            
            var oldTimers = oldTimersAndNoobs.Item1.Count();

            var noobs = oldTimersAndNoobs.Item2.Count();
            
        }

        [Test]
        public void LeftJoin()
        {
            var employees = Employees.GetAll();

            var funnyStories = new[]
                                   {
                                       new
                                           {
                                               EmployeeId = "25011600",
                                               Story = "Yacked at Christmas party"
                                           },
                                       new
                                           {
                                               EmployeeId = "643805155",
                                               Story = "Pooped pants at Christmas party"
                                           }
                                   };

            var result = employees
                .LeftJoin(funnyStories,
                          e => e.Id,
                          s => s.EmployeeId,
                          (key, emp, story) => new
                                                   {
                                                       Name = emp.FirstName, 
                                                       Story = story
                                                   })
                .ToList();
            
        }

    }
}