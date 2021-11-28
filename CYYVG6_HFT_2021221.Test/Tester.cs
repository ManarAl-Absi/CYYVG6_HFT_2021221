using CYYVG6_HFT_2021221.Repository;
using CYYVG6_HFT_2021221.Logic;
using Moq;
using NUnit.Framework;
using System;
using CYYVG6_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace CYYVG6_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        FacultyLogic fl;
        StudentLogic sl;
        EmployeeLogic el;

        [SetUp]
        public void doesExist()
        {
            var mockFacultyRepo = new Mock<IFacultyRepository>();

            Student fakeStudent = new Student();
            fakeStudent.StudentId = 1;
            fakeStudent.FulName = "Moni Loe";

            var faculties = new List<Faculty>()
            {
                new Faculty()
                {
                    FacultyId = 1,
                    FacultyName = "John von Neumann Faculty of Informatics",
                    FacultyAddress= "1034 Budapest, Becsi u. 96b",
                    Student = fakeStudent
                }
            }.AsQueryable();
            mockFacultyRepo.Setup((f) => f.GetAll()).Returns(faculties);
            fl = new FacultyLogic(mockFacultyRepo.Object);

        }

        [Test]
        public void TestAVGAgeOfStudents()
        {
            var result = sl.AVGAgeOfStudents();
            Assert.That(result, Is.EqualTo(24));
        }

        [Test]
        public void TestNumOfStudentInUniversit()
        {
            var result = sl.NumOfStudentInUniversity();
            Assert.That(result, Is.EqualTo(4));
        }


        [Test]
        public void TestSalaryUniversityPayForAllEmp()
        {
            var result = el.SalaryUniversityPayForAllEmp();
            Assert.That(result, Is.EqualTo(10800));
        }


        [Test]
        public void TestMoneyUniversityEarnFromStudent()
        {
            var result = sl.MoneyUniversityEarnFromStudent();
            Assert.That(result, Is.EqualTo(11100));
        }


        [Test]
        public void TestHighestSalary()
        {
            var result = el.HighestSalary();
            Assert.That(result, Is.EqualTo(5000));
        }

    }
}
