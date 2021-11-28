using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentsOfObudaUniDbContext db;
        public StudentRepository(StudentsOfObudaUniDbContext db)
        {
            this.db = db;
        }

        public void Create(Student student)
        {
            this.db.Students.Add(student);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student stud = this.Read(id);
            this.db.Students.Remove(stud);
            this.db.SaveChanges();
        }

        public IQueryable<Student> GetAll()
        {
            return db.Students;
        }

        public Student Read(int id)
        {
            return db.Students.FirstOrDefault(f => f.StudentId == id);
        }

        public void Update(Student student)
        {
            Student stud = this.Read(student.StudentId);
            stud.FulName = student.FulName;
            this.db.SaveChanges();
        }
    }
}
