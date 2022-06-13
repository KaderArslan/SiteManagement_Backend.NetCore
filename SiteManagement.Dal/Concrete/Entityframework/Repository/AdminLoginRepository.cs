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
    public class AdminLoginRepository : GenericRepository<Admin>, IAdminLoginRepository
    {
        public AdminLoginRepository(DbContext context) : base(context)
        {
        }

        public Admin Login(Admin login)
        {
            var admin = dbset.Where(x => x.AdminEmail == login.AdminEmail && x.AdminPassword == login.AdminPassword).SingleOrDefault();

            return admin;
        }
    }
}
