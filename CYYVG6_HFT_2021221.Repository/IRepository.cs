using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);       //To find an object by the id
        IQueryable<T> GetAll();     //To every record from the database
        void Insert(T entity);      //To insert a record into the database
        void Remove(int id);        //To revove a record from the database
    }
}
