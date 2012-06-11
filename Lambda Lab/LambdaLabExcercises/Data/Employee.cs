using System;

namespace LambdaLabExcercises.Data
{
    public class Employee
    {
        public Employee()
        {
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Street { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
    }
}