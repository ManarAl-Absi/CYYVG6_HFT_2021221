using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {

        private DbContext DbCnxt;

        public Repository(DbContext DbCnxt)
        {
            this.DbCnxt = DbCnxt;
        }

        protected DbContext Context 
        { 
            get => this.DbCnxt;
            set => this.DbCnxt = value;
        }
        public IQueryable<T> GetAll()
        {
            return this.DbCnxt.Set<T>();
        }

        public abstract T GetOne(int id);

        public abstract void Insert(T entity);

        public abstract void Remove(int id);
    }
}
