using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    interface IUniversityLogic
    {
        Faculty GetOneFaculty(int id);
        IList<Faculty> GetAllFaculties();

        Student GetOneStudent(int id);
        IList<Student> GetAllStudents();

        Employee GetOneEmployee(int id);
        IList<Employee> GetAllEmployees();

        void ChangeEmployeeSalary(int id, int newSalary);
        void ChangeEmployeePosition(int id, string newPosition);
        void changeStudentTitutionPrice(int id, int newPrice);
        void changeFacultyAddress(int id, string newAdress);
        void ChangeFacultyName(int id, string newName);

        


    }
}
