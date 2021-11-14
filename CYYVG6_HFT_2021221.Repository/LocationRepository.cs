using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DbContext DbCntx)
            : base(DbCntx)
        {
        }

        public void ChangeAddress(int id, string newAddress)
        {
            var location = this.GetOne(id);
            if (location == null)
            {
                throw new InvalidOperationException("Sorry! Wrong address");
            }
            location.Address = newAddress;
            this.Context.SaveChanges();
        }

        public override Location GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.LocationId == id);
        }

        public override void Insert(Location entity)
        {
            this.Context.Set<Location>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Location loc = this.GetOne(id);
            this.Context.Set<Location>().Remove(loc);
            this.Context.SaveChanges();
        }

        
    }
}
