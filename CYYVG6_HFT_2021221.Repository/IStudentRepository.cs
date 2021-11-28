using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public interface IStudentRepository 
    {
        void Create(Student student);
        void Delete(int id);
        IQueryable<Student> GetAll();
        Student Read(int id);
        void Update(Student student);
    }
}
