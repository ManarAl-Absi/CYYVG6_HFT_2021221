using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void ChangeAddress(int id, string newAddress);
        void ChangePosition(int id, string newPosition);
        void ChangeEmployeeSalary(int id, int newSalary);
    }
}
