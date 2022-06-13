using SiteManagement.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        //Listeleme
        IResponse<List<TDto>> GetAll();

        //Filreli Listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);

        //Find, Getirme
        IResponse<TDto> Find(int id);

        //Ekleme, Kaydetme
        //IResponse<TDto> Add(TDto item, bool saveChanges = true);

        //Async Kaydetme
        //Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true);

        //Guncelleme
        //IResponse<TDto> Update(TDto item, bool saveChanges = true);

        //Async Guncelleme
        //Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);

        //Silme
        //IResponse<bool> DeleteById(int id, bool saveChanges = true);

        //Async Silme
        //Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);

        //IQueryable Listeleme, bize TDto doner
        //veritabanında bir sorgu calistiracaksak bununla yapariz IQueryable
        IResponse<IQueryable<TDto>> GetQueryable();

        void Save();
    }
}
