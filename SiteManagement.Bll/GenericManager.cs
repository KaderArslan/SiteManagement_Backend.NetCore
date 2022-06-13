using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Base;
using SiteManagement.Entity.IBase;
using SiteManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        //Dal'la haberlesebilmesi icin bazi senaryolar
        //1. UnitOfWork
        //2. ServiceProvider
        //3. GenericRepository Yonetimi
        //4. constructor

        #region Variables
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor
        public GenericManager(IServiceProvider service)//generic'in tipi service
        {
            //unitofWork, service ve repositoryi aktif edecegiz
            this.service = service; //service startup'tan gelecek
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
        }
        #endregion

        #region Methods
        //public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        //{
        //    try
        //    {
        //        var model = ObjectMapper.Mapper.Map<T>(item);

        //        var result = repository.Add(model);

        //        if (saveChanges)
        //            Save();

        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status200OK,
        //            Message = "Success",
        //            Data = ObjectMapper.Mapper.Map<T, TDto>(result)
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error{ex.Message}",
        //            Data = null
        //        };
        //    }
        //}

        //public async Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        //{
        //    try
        //    {
        //        var model = ObjectMapper.Mapper.Map<T>(item);

        //        var result = await repository.AddAsync(model); //cevap gelirken beklemesi lazim

        //        if (saveChanges)
        //            Save();

        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status200OK,
        //            Message = "Success",
        //            Data = ObjectMapper.Mapper.Map<T, TDto>(result)
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error{ex.Message}",
        //            Data = null
        //        };
        //    }
        //}

        //public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        //{
        //    try
        //    {
        //        repository.Delete(id);//id istiyor, burada hata varsa asagiya inmez
        //        if (saveChanges)
        //            Save();

        //        return new Response<bool> //ne istiyorsa onu dondurur
        //        {
        //            StatusCode = StatusCodes.Status200OK,
        //            Message = "Success",
        //            Data = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<bool>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error:{ex.Message}",  //"Error"+ex.Message
        //            Data = false
        //        };
        //    }
        //}

        //public Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true)
        //{
        //    throw new NotImplementedException();
        //}

        public IResponse<TDto> Find(int id)
        {
            //Find a gelen T olur TDto ya donusur
            try
            {
                var entity = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id));
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetAll(expression);
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));
                //bir datayı cektigimde ve select uyguladigimda zaten queryable olarak gelir
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        //public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        //{
        //    try
        //    {
        //        var model = ObjectMapper.Mapper.Map<T>(item);

        //        var result = repository.Update(model);

        //        if (saveChanges)
        //            Save();

        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status200OK,
        //            Message = "Update Success",
        //            Data = ObjectMapper.Mapper.Map<T, TDto>(result)
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<TDto>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error{ex.Message}",
        //            Data = null
        //        };
        //    }
        //}

        //public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        //{
        //    throw new NotImplementedException();
        //}

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        #endregion

    }
}
