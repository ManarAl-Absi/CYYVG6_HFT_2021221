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
    public class FacultyRepository : IFacultyRepository
    {
        StudentsOfObudaUniDbContext db;
        public FacultyRepository(StudentsOfObudaUniDbContext db)
        {
            this.db = db;
        }

        public void Create(Faculty faculty)
        {
            this.db.Faculties.Add(faculty);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Faculty fac = this.Read(id);
            this.db.Faculties.Remove(fac);
            this.db.SaveChanges();
        }

        public IQueryable<Faculty> GetAll()
        {
            return db.Faculties;
        }

        public Faculty Read(int id)
        {
            return db.Faculties.FirstOrDefault(f => f.FacultyId == id);
        }

        public void Update(Faculty faculty)
        {
            Faculty fac = this.Read(faculty.FacultyId);
            fac.FacultyName = faculty.FacultyName;
            this.db.SaveChanges();

        }
    }

}
