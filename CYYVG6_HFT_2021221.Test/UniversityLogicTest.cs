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
    public class UniversityLogicTest
    {
      
        //private UniversityLogic universityLogic;

        FacultyLogic ul;
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
            ul = new FacultyLogic(mockFacultyRepo.Object);

        }

        [Test]
        public void TestAVGAgeOfStudents()
        {
            var result = ul.AVGAgeOfStudents();
            Assert.That(result, Is.EqualTo(22));
        }

        [Test]
        public void TestNumOfStudentInUniversit()
        {
            var result = ul.NumOfStudentInUniversity();
            Assert.That(result, Is.EqualTo(4000));
        }


        [Test]
        public void TestSalaryUniversityPayForAllEmp()
        {
            var result = ul.SalaryUniversityPayForAllEmp();
            Assert.That(result, Is.EqualTo(10800));
        }


        [Test]
        public void TestMoneyUniversityEarnFromStudent()
        {
            var result = ul.MoneyUniversityEarnFromStudent();
            Assert.That(result, Is.EqualTo(11100));
        }


        [Test]
        public void TestHighestSalary()
        {
            var result = ul.HighestSalary();
            Assert.That(result, Is.EqualTo(5000));
        }

    }
}
