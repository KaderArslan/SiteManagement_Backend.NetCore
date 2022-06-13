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
    public class ApartmentAdminRepository : GenericRepository<Apartment>, IApartmentAdminRepository
    {
        public ApartmentAdminRepository(DbContext context) : base(context)
        {
        }

        public Apartment Add(Apartment item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));//asagidaki delete
        }

        public bool Delete(Apartment item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public List<Apartment> GetAllApartments()
        {
            var apartment = dbset.OrderBy(a => a.ApartmentId).ThenBy(a => a.ApartmentIsEmpty).ToList();

            return apartment;

        }

        public Apartment Update(Apartment item)
        {
            dbset.Update(item);
            return item;
        }

    }
}
