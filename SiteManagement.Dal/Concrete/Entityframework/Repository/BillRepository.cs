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
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(DbContext context) : base(context)
        {
        }
    }
}
