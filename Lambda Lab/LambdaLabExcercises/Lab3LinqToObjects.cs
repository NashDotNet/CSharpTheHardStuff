using System.Collections.Generic;
using System.Linq;
using LambdaLabExcercises.Data;
using NUnit.Framework;

namespace LambdaLabExcercises
{
    [TestFixture]
    public class Lab3LinqToObjects
    {
        [Test]
        public void GetCanadianProvinces()
        {
            IEnumerable<StateProvince> stateProvinces = StateProvinces.GetAll();

            List<string> canadianProvinces =
                stateProvinces
                    .Where(x => x.Country == "CA")
                    .Select(x => x.Name)
                    .ToList();

            Assert.AreEqual(13, canadianProvinces.Count());

            Assert.Contains("Saskatchewan", canadianProvinces);
        }


        [Test]
        public void GetEmployeeNamedKevinHomer()
        {
            var data = Employees.GetAll();

            var homer = data.Single(x => x.FirstName == "Kevin" && x.LastName == "Homer");

            Assert.AreEqual("555-555-0113", homer.Phone);
        }

        [Test]
        public void GroupBy()
        {
            var data = Employees.GetAll();

            var hires =
                data.GroupBy(x => x.HireDate.Year)
                .Select(x => new {Year = x.Key, Hires = x.Count()})
                .ToList();

        }

        [Test]
        public void JoinToGetBritishEmployees()
        {
            var employees = Employees.GetAll();
            var stateProvinces = StateProvinces.GetAll();

            var britishStateProvinces = stateProvinces.Where(x => x.Country == "GB");

            var joinedData =
                employees.Join(britishStateProvinces,
                               e => e.StateProvinceID,
                               sp => sp.StateProvinceID,
                               (employee, stateProvince) => employee);

            IEnumerable<string> brits = joinedData
                .Select(x => x.FirstName + " " + x.LastName);

        }

    }
}