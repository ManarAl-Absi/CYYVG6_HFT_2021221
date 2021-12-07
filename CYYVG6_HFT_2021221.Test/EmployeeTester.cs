using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Test
{
    [TestFixture]
    public class EmployeeTester
    {
       EmployeeLogic el;

        [SetUp]
        public void Init()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();

            Faculty fakeFaculty = new Faculty();
            fakeFaculty.FacultyId = 1;
            fakeFaculty.FacultyName = "Keleti Faculty of Economics";

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    FulName = "John Tomas",
                    Age = 51,
                    Address = "1032 Budapest, Hun u. 6",
                    Email = "john@gmail.com",
                    Position = "Professor",
                    Salary = 6000
                },
                 new Employee()
                {
                    EmployeeId = 2,
                    FulName = "Joe Foe",
                    Age = 31,
                    Address = "1052 Budapest, Milla u. 4",
                    Email = "joefoe@gmail.com",
                    Position = "Lecturer",
                    Salary = 4000
                 }
            }.AsQueryable();
            mockEmployeeRepo.Setup((e) => e.GetAll()).Returns(employees);
            el = new EmployeeLogic(mockEmployeeRepo.Object);

        }

        [Test]
        public void SalaryUniversityPayForAllEmp()
        {
            var result = el.SalaryUniversityPayForAllEmp();
            Assert.That(result, Is.EqualTo(10000));
        }


        [Test]
        public void TestHighestSalary()
        {
            var result = el.HighestSalary();
            Assert.That(result, Is.EqualTo(6000));
        }

        [TestCase(1)]
        public void TestReadEmployee(int id)
        {
            var x = el.Read(id);
            var y = el.Read(id);

            Assert.That(x, Is.SameAs(y));

        }
        [Test]
        public void TestTrowsExceptionOfEmployeeDelete()
        {
            Assert.That(() => el.Delete(-2), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestGetAllEmployees()
        {
            Assert.That(this.el.GetAll().Count, Is.EqualTo(2));
        }

    }
}
