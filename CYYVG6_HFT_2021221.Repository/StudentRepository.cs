using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext DbCntx)
            : base(DbCntx)
        {
        }

        public void ChangeMajorWithinTheFaculty(int id, string newMajor)
        {
            var student = this.GetOne(id);
            if (student == null)
            {
                throw new InvalidOperationException("Sorry! This student is not in our university");
            }
            student.Major = newMajor;
            this.Context.SaveChanges();
        }

        public override Student GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.StudentId == id);
        }

        public override void Insert(Student entity)
        {
            this.Context.Set<Student>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Student stud = this.GetOne(id);
            this.Context.Set<Student>().Remove(stud);
            this.Context.SaveChanges();
        }
    }
}
