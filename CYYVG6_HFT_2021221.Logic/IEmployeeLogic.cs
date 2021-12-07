using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public interface IEmployeeLogic
    {
        void Create(Employee employee);
        void Delete(int id);
        IEnumerable<Employee> GetAll();
        Employee Read(int id);
        void Update(Employee employee);
        //int SalaryUniversityPayForAllEmp();
        //int HighestSalary();
    }
}
