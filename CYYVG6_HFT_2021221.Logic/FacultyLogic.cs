using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public class FacultyLogic : IFacultyLogic
    {
         IFacultyRepository facultyRepository;
        
        public FacultyLogic(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

        public void Create(Faculty faculty)
        {
            if( faculty.FacultyName.Length < 10)
            {
                throw new ArgumentException("Invalid faculty name");
            }
            facultyRepository.Create(faculty);
        }

        public void Delete(int id)
        {
            facultyRepository.Delete(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
            return facultyRepository.GetAll();
        }
        public Faculty Read(int id)
        {
            return facultyRepository.Read(id);
        }

        public void Update(Faculty faculty)
        {
            facultyRepository.Update(faculty);
        }
       

    }
}
