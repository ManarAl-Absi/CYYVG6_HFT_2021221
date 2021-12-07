using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public class FacultyLogic : IFacultyLogic
    {
         IFacultyRepository facultyRepository;
        IStudentRepository studentRepository;
        IEmployeeRepository employeeRepository;
        public FacultyLogic(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;

        }
        public FacultyLogic(IFacultyRepository facultyRepository, IStudentRepository studentRepository, IEmployeeRepository employeeRepository)
        {
            this.facultyRepository = facultyRepository;
            this.studentRepository = studentRepository;
            this.employeeRepository = employeeRepository;
        }

        public void Create(Faculty faculty)
        {
            if( faculty.FacultyName.Length < 10)
            {
                throw new ArgumentException("Invalid faculty name");
            }
            facultyRepository.Create(faculty);
        }

        public void Delete(int id)
        {
            facultyRepository.Delete(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
            return facultyRepository.GetAll();
        }
        public Faculty Read(int id)
        {
            return facultyRepository.Read(id);
        }

        public void Update(Faculty faculty)
        {
            facultyRepository.Update(faculty);
        }

        public Faculty FacultyOfStudent(int id)
        {
            Student s = studentRepository.Read(id);
            Faculty f = facultyRepository.Read(s.FacultyId);
            return f;
        }

        public Faculty FacultyPaysHighestSalary()
        {
            int highest = employeeRepository.GetAll().Max(x => x.Salary);
            Employee emp = employeeRepository.GetAll()
                .Where(x => x.Salary == highest)
                .FirstOrDefault();
            Faculty fac = facultyRepository.Read(emp.FacultyId);
            return fac;

        }

        public Faculty FacultyPaysLowestSalary()
        {
            int lowest  = employeeRepository.GetAll().Min(x => x.Salary);
            Employee emp = employeeRepository.GetAll()
                .Where(x => x.Salary == lowest)
                .FirstOrDefault();
            Faculty fac = facultyRepository.Read(emp.FacultyId);
            return fac;
        }

        public Employee SupervisorOfAStudent(int id)
        {
            Student stud = studentRepository.Read(id);
            Faculty fac = facultyRepository.Read(stud.StudentId);
            Employee emp = employeeRepository.GetAll()
                .Where(x => fac.FacultyId == x.FacultyId)
                .Where(x => x.Position == "Supervisor")
                .FirstOrDefault();
            return emp;
        }
      

        public IList<FacultyEarningsResult> FacultyEarnings()
        {
            IList<Faculty> facultiesList = this.facultyRepository.GetAll().ToList();
            IList<Student> studentList = this.studentRepository.GetAll().ToList();

            var result = from faculties in facultiesList
                         join students in studentList
                                 on faculties.FacultyId equals students.FacultyId
                         group students by students.FacultyId into g
                         let counting = g.Count()
                         select new FacultyEarningsResult()
                         {
                             facultyId = g.Key,
                             facultyName = this.facultyRepository.Read(g.Key).FacultyName,
                             facultyAddress = this.facultyRepository.Read(g.Key).FacultyName,
                             TotalEarnings = counting * this.studentRepository.Read(g.Key).TitutionPrice,
                         };

            return result.ToList();
        }
        public Task<IList<FacultyEarningsResult>> FacultyEarningsAsync()
        {
            return Task.Run(this.FacultyEarnings);
        }
    }
}
