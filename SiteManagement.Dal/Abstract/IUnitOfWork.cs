using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;

        //transaction baslatma
        bool BeginTransaction();
        //RollBack hata durumunda surecin geri alinmasini saglayan islemdir
        bool RollBackTransaction();
        //Transaction onaylama
        int SaveChanges();
    }
}
