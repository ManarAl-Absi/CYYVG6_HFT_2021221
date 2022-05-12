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
    public class EmployeeRepository : IEmployeeRepository
    {
        StudentsOfObudaUniDbContext db;
        public EmployeeRepository(StudentsOfObudaUniDbContext db)
        {
            this.db = db;
        }

        public void Create(Employee employee)
        {
            this.db.Employees.Add(employee);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee emp = this.Read(id);
            this.db.Employees.Remove(emp);
            this.db.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee Read(int id)
        {
            return db.Employees.FirstOrDefault(f => f.EmployeeId == id);
        }

        public void Update(Employee employee)
        {
            var old = Read(employee.EmployeeId);
            if (old == null)
            {
                throw new ArgumentException("Employee not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(employee));
                }
            }
            db.SaveChanges();
        }
    }
}
