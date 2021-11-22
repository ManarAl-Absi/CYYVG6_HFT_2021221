using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    class UniversityLogic : IUniversityLogic
    {
        private IStudentRepository studentRepository;
        private IEmployeeRepository employeeRepository;
        private IFacultyRepository facultyRepository;

        public UniversityLogic(IStudentRepository studentRepository, IEmployeeRepository employeeRepository, IFacultyRepository facultyRepository)
        {
            this.studentRepository = studentRepository;
            this.employeeRepository = employeeRepository;
            this.facultyRepository = facultyRepository;
        }

        public void ChangeEmployeePosition(int id, string newPosition)
        {
            this.employeeRepository.ChangePosition(id, newPosition);
        }

        public void ChangeEmployeeSalary(int id, int newSalary)
        {
            this.employeeRepository.ChangeEmployeeSalary(id, newSalary);
        }

        public void changeFacultyAddress(int id, string newAdress)
        {
            this.facultyRepository.changeFacultyAddress(id, newAdress);
        }

        public void ChangeFacultyName(int id, string newName)
        {
            this.facultyRepository.ChangeFacultyName(id, newName);
        }

        public void changeStudentTitutionPrice(int id, int newPrice)
        {
            this.studentRepository.ChangePrice(id, newPrice);
        }

        public IList<Employee> GetAllEmployees()
        {
            return this.employeeRepository.GetAll().ToList();
        }

        public IList<Faculty> GetAllFaculties()
        {
            return this.facultyRepository.GetAll().ToList();
        }

        public IList<Student> GetAllStudents()
        {
            return this.studentRepository.GetAll().ToList();
        }

        public Employee GetOneEmployee(int id)
        {
            Employee emp = this.employeeRepository.GetOne(id);
            if (emp == null)
            {
                throw new InvalidOperationException("ERROR: Employee not found!");
            }

            return this.employeeRepository.GetOne(id);
        }

        public Faculty GetOneFaculty(int id)
        {
            Faculty fac = this.facultyRepository.GetOne(id);
            if (fac == null)
            {
                throw new InvalidOperationException("ERROR: Faculty not found!");
            }

            return this.facultyRepository.GetOne(id);
        }

        public Student GetOneStudent(int id)
        {
            Student stud = this.studentRepository.GetOne(id);
            if (stud == null)
            {
                throw new InvalidOperationException("ERROR: Student not found!");
            }

            return this.studentRepository.GetOne(id);
        }

        public Employee InsertNewEmployee(string fulName, int age, string address, string email, string position, int salary)
        {
            Employee newEmp = new Employee()
            {
                FulName = fulName,
                Age = age,
                Address = address,
                Email = email,
                Position = position,
                Salary = salary,
            };
            this.employeeRepository.Insert(newEmp);
            return newEmp;
        }
        public void DeleteEmployee(int id)
        {
            Employee emp = this.employeeRepository.GetOne(id);
            if (emp == null)
            {
                throw new InvalidOperationException("ERROR: Employee not Found!");
            }
            else
            {
                this.employeeRepository.Remove(id);
            }
        }

        public Student InsertNewStudent(string fulName, int age, string major, string gender, string nationalty, int titutionPrice, bool speaksHungarian)
        {
            Student newStud = new Student()
            {
                FulName = fulName,
                Age = age,
                Major = major,
                Gender = gender,
                Nationality = nationalty,
                TitutionPrice = titutionPrice,
                SpeaksHungarian = speaksHungarian,
            };
            this.studentRepository.Insert(newStud);
            return newStud;
        }
        public void DeleteStudent(int id)
        {
            Student stud = this.studentRepository.GetOne(id);
            if (stud == null)
            {
                throw new InvalidOperationException("ERROR: Student not Found!");
            }
            else
            {
                this.studentRepository.Remove(id);
            }
        }
        public double AVGAgeOfStudents()
        {
            return studentRepository.GetAll().Average(a => a.Age);
        }
        public int SalaryUniversityPayForAllEmp()
        {
            return employeeRepository.GetAll().Sum(s => s.Salary);
        }
    }
}
