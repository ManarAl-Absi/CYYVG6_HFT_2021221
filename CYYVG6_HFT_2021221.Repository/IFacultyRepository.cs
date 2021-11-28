using CYYVG6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public interface IFacultyRepository 
    {
        void Create(Faculty faculty);
        void Delete(int id);
        IQueryable<Faculty> GetAll();
        Faculty Read(int id);
        void Update(Faculty faculty);
       
    }
}
