using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IEmployeeRepository employeeRepository;

        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Create(Employee employee)
        {
            if (!employee.FulName.Contains(" "))
            {
                throw new ArgumentException("Invalid employee name: Does not have surname");
            }
            employeeRepository.Create(employee);
        }

        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public int HighestSalary()
        {
            return employeeRepository.GetAll().Max(s => s.Salary);
        }

        public Employee Read(int id)
        {
            return employeeRepository.Read(id);
        }

        public int SalaryUniversityPayForAllEmp()
        {
            return employeeRepository.GetAll().Sum(s => s.Salary);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}
