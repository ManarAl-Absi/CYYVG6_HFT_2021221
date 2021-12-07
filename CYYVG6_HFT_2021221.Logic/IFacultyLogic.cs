using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public interface IFacultyLogic
    {
        void Create(Faculty faculty);
        void Delete(int id);
        IEnumerable<Faculty> GetAll();
        Faculty Read(int id);
        void Update(Faculty faculty);
        Faculty FacultyOfStudent(int id);
        Faculty FacultyPaysHighestSalary();
        Faculty FacultyPaysLowestSalary();
        Employee SupervisorOfAStudent(int id);
        IList<FacultyEarningsResult> FacultyEarnings();
    }

}
