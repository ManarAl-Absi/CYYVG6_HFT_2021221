using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public interface IEmployeeRepository 
    {
        void Create(Employee employee);
        void Delete(int id);
        IQueryable<Employee> GetAll();
        Employee Read(int id);
        void Update(Employee employee);
    }
}
