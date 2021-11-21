using CYYVG6_HFT_2021221.Repository;
using CYYVG6_HFT_2021221.Logic;
using Moq;
using NUnit.Framework;
using System;

namespace CYYVG6_HFT_2021221.Test
{
    [TestFixture]
    public class UniversityLogicTest
    {
        private Mock<IStudentRepository> studentRepository;
        private Mock<IEmployeeRepository> employeeRepository;
        private Mock<IFacultyRepository> facultyRepository;
        //private UniversityLogic universityLogic;

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
