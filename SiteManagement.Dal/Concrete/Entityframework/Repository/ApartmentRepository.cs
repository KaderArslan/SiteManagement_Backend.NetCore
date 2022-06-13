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
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
