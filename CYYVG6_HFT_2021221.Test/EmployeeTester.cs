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
            fakeFaculty.FacultyName = "Deak Faculty of Business";

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    FulName = "Bari Attila",
                    Age = 30,
                    Address = "1074 Budapest, opqr u. 2",
                    Email = "opqt@gmail.com",
                    Position = "Lecturer",
                    Salary = 3000,
                    Faculty = fakeFaculty
                },
                new Employee()
                {
                    EmployeeId = 2,
                    FulName = " Tomas Blaha ",
                    Age = 53,
                    Address = "1074 Budapest, vwxy u. 4",
                    Email = "vwxy@gmail.com",
                    Position = "Professor",
                    Salary = 6000,
                    Faculty = fakeFaculty
                }
            }.AsQueryable();
            mockEmployeeRepo.Setup((e) => e.GetAll()).Returns(employees);
            el = new EmployeeLogic(mockEmployeeRepo.Object);

        }

        [Test]
        public void TestSalaryUniversityPayForAllEmp()
        {
            var result = el.SalaryUniversityPayForAllEmp();
            Assert.That(result, Is.EqualTo(9000));
        }


        [Test]
        public void TestHighestSalary()
        {
            var result = el.HighestSalary();
            Assert.That(result, Is.EqualTo(6000));
        }

        [TestCase(1)]
        public void TestEmployee(int id)
        {
            var x = el.Read(id);
            var y = el.Read(id);

            Assert.That(x, Is.SameAs(y));


            //this.el.Create(new Employee()
            //{
            //    FulName = name
            //});
            //Assert.That(el.GetEmployeeByID(id).FulName, Is.EqualTo(name));
        }

        [Test]
        public void GetOneBlog_ReturnsCorrectInstance()
        {
            var result = this.el.Read(1);

            Assert.That(result.Position, Is.EqualTo("Lecturer"));
        }

    }
}
