using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public class StudentLogic : IStudentLogic
    {
         IStudentRepository studentRepository;

        public StudentLogic(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void Create(Student student)
        {
            if (!student.FulName.Contains(" "))
            {
                throw new ArgumentException("Invalid student name: Does not have surname");
            }
            studentRepository.Create(student);
        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid Student ID");
            }
            studentRepository.Delete(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public Student Read(int id)
        {
            return studentRepository.Read(id);
        }

        public void Update(Student student)
        {
            studentRepository.Update(student);
        }

        //public int MoneyUniversityEarnFromStudent()
        //{
        //    return studentRepository.GetAll().Sum(s => s.TitutionPrice);
        //}

        //public int NumOfStudentInUniversity()
        //{
        //    return studentRepository.GetAll().Count();
        //}

        //public double AVGAgeOfStudents()
        //{
        //    return studentRepository.GetAll().Average(a => a.Age);
        //}
    }
}
