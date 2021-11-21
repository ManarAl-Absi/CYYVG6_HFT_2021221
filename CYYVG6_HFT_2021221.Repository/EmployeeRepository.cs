using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext DbCntx)
            : base(DbCntx)
        {
        }

        public void ChangeAddress(int id, string newAddress)
        {
            var employee = this.GetOne(id);
            if (employee == null)
            {
                throw new InvalidOperationException("Sorry! Wrong address");
            }
            employee.Address = newAddress;
            this.Context.SaveChanges();
        }

        public override Employee GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.EmployeeId == id);
        }

        public override void Insert(Employee entity)
        {
            this.Context.Set<Employee>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Employee emp = this.GetOne(id);
            this.Context.Set<Employee>().Remove(emp);
            this.Context.SaveChanges();
        }

        
    }
}
