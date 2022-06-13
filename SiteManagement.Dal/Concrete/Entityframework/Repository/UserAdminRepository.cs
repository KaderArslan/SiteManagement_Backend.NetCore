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
    public class UserAdminRepository : GenericRepository<User>, IUserAdminRepository
    {
        public UserAdminRepository(DbContext context) : base(context)
        {
        }

        public User Add(User item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));//asagidaki delete
        }

        public bool Delete(User item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public User Update(User item)
        {
            dbset.Update(item);
            return item;
        }

    }
}
