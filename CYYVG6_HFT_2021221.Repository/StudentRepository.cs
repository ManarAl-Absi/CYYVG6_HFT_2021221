using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext DbCntx)
            : base(DbCntx)
        {
        }

        public override Student GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Student entity)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
