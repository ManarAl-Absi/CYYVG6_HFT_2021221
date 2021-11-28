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
        private Mock<IStudentRepository> studentRepository;
        private Mock<IEmployeeRepository> employeeRepository;
        private Mock<IFacultyRepository> facultyRepository;
        //private UniversityLogic universityLogic;

        UniversityLogic ul;
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
            ul = new UniversityLogic(mockFacultyRepo.Object);

        }

        [Test]
        public void TestStudentCosts()
        {
          
        }

        [Test]
        public void TestStudentMajor()
        {

        }


        [Test]
        public void TestEmployeeEarnings()
        {
        }

        
        [Test]
        public void TestEmployeePosition()
        {
        }

        
        [OneTimeSetUp]
        public void CreateLogicWithMocks()
        {
        }

        }
}
