using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    class ClientLogic : IClientLogic
    {
        private IEmployeeRepository employeeRepository;
        private IStudentRepository studentRepository;
        private IFacultyRepository facultyRepository;

        public ClientLogic(IEmployeeRepository employeeRepository, IStudentRepository studentRepository, IFacultyRepository facultyRepository)
        {
            this.employeeRepository = employeeRepository;
            this.studentRepository = studentRepository;
            this.facultyRepository = facultyRepository;
        }

        public void ChangeEmployeeAddress(int id, string newAddress)
        {
            this.employeeRepository.ChangeAddress(id, newAddress);
        }

        public void ChangeEmployeeEmail(int id, string newEmail)
        {
            this.employeeRepository.ChangeEmail(id, newEmail);
        }

        public void ChangeStudentMajor(int id, string newMajor)
        {
            this.studentRepository.ChangeMajorWithinTheFaculty(id, newMajor);
        }
        public Faculty InsertNewFaculty(string facultyName, string facultyAddress)
        {
            Faculty newFac = new Faculty()
            {
                FacultyName = facultyName,
                FacultyAddress = facultyAddress,
                
            };
            this.facultyRepository.Insert(newFac);
            return newFac;
        }
        public void DeleteFaculty(int id)
        {
            Faculty Fac = this.facultyRepository.GetOne(id);
            if (Fac == null)
            {
                throw new InvalidOperationException("ERROR: Faculty not Found!");
            }
            else
            {
                this.facultyRepository.Remove(id);
            }
        }
    }
}
