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
    public class UserLoginRepository : GenericRepository<User>, IUserLoginRepository
    {
        public UserLoginRepository(DbContext context) : base(context)
        {
        }

        public User Login(User login)
        {
            var user = dbset.Where(x => x.UserIsActive && x.UserEmail == login.UserEmail && x.UserPassword == login.UserPassword).SingleOrDefault();

            return user;
        }
    }
}
