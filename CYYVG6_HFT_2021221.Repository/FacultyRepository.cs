using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(DbContext DbCntx)
            : base(DbCntx)
        {
        }

        public void changeFacultyAddress(int id, string newAdress)
        {
            var faculty = this.GetOne(id);
            if (faculty == null)
            {
                throw new InvalidOperationException("Sorry! Wrong faculty");
            }
            faculty.FacultyAddress = newAdress;
            this.Context.SaveChanges();
        }

        public void ChangeFacultyName(int id, string newName)
        {
            var faculty = this.GetOne(id);
            if (faculty == null)
            {
                throw new InvalidOperationException("Sorry! Wrong faculty");
            }
            faculty.FacultyName = newName;
            this.Context.SaveChanges();

        }

        public override Faculty GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x =>x.FacultyId == id);
        }

        public override void Insert(Faculty entity)
        {
            this.Context.Set<Faculty>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Faculty fac = this.GetOne(id);
            this.Context.Set<Faculty>().Remove(fac);
            this.Context.SaveChanges();
        }
    }
}
