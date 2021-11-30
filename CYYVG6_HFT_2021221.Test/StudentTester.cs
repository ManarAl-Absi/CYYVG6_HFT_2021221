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
    public class StudentTester
    {
        StudentLogic sl;

        [SetUp]
        public void Init()
        {
            var mockStudentRepo = new Mock<IStudentRepository>();

            Faculty fakeFaculty = new Faculty();
            fakeFaculty.FacultyId = 1;
            fakeFaculty.FacultyName = "Keleti Faculty of Economics";

            var students = new List<Student>()
            {
                new Student()
                {
                    StudentId = 1,
                    FulName = "Tom Joe",
                    Major = "Economics",
                    Gender = "Male",
                    Age = 21,
                    Nationality = "American",
                    SpeaksHungarian = false,
                    TitutionPrice = 2000,
                    Faculty = fakeFaculty
                }
            }.AsQueryable();
            mockStudentRepo.Setup((s) => s.GetAll()).Returns(students);
            sl = new StudentLogic(mockStudentRepo.Object);

        }

        [Test]
        public void TestAVGAgeOfStudents()
        {
            var result = sl.AVGAgeOfStudents();
            Assert.That(result, Is.EqualTo(21));
        }

        [Test]
        public void TestNumOfStudentInUniversit()
        {
            var result = sl.NumOfStudentInUniversity();
            Assert.That(result, Is.EqualTo(1));
        }



        [Test]
        public void TestMoneyUniversityEarnFromStudent()
        {
            var result = sl.MoneyUniversityEarnFromStudent();
            Assert.That(result, Is.EqualTo(2000));
        }
        [Test]
        public void TestRead()
        {
            var result = sl.Read(1);
            Assert.That(result.Age, Is.AtMost(27));
        }


    }
}
