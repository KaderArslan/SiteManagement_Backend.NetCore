using SiteManagement.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IGenericRepository<T> where T : IEntityBase
    {
        //Listeleme
        List<T> GetAll();

        //Filreli Listeleme
        List<T> GetAll(Expression<Func<T, bool>> expression);

        //Find, Getirme
        T Find(int id);

        //Ekleme, Kaydetme
        //T Add(T item);

        //Async Kaydetme
        //Task<T> AddAsync(T item);

        //Guncelleme 
        //T Update(T item);

        //Silme
        //bool Delete(int id);
        //Generic Silme
        //bool Delete(T item);

        //IQueryable Listeleme
        IQueryable<T> GetQueryable();
    }
}
