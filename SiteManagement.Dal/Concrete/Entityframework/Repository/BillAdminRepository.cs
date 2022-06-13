using Microsoft.EntityFrameworkCore;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Concrete.Entityframework.Repository
{
    public class BillAdminRepository : GenericRepository<Bill>, IBillAdminRepository
    {
        public BillAdminRepository(DbContext context) : base(context)
        {
        }

        public Bill Add(Bill item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));//asagidaki delete
        }

        public bool Delete(Bill item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public Bill Update(Bill item)
        {
            dbset.Update(item);
            return item;
        }

    }
}
