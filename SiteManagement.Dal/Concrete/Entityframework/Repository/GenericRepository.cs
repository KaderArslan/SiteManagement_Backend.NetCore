﻿using Microsoft.EntityFrameworkCore;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Concrete.Entityframework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();
        }

        #region Methods

        //public T Add(T item)
        //{
        //    context.Entry(item).State = EntityState.Added;
        //    dbset.Add(item);

        //    return item;
        //}

        //public async Task<T> AddAsync(T item)
        //{
        //    context.Entry(item).State = EntityState.Added;
        //    await dbset.AddAsync(item);
        //    return item;
        //}

        //public bool Delete(int id)
        //{
        //    return Delete(Find(id));//asagidaki delete
        //}

        //public bool Delete(T item)
        //{
        //    if (context.Entry(item).State == EntityState.Detached)
        //    {
        //        context.Attach(item);
        //    }
        //    return dbset.Remove(item) != null;
        //}

        public T Find(int id)
        {
            //Find bir modelde primary keye gore calisir
            return dbset.Find(id);
        }

        public List<T> GetAll()
        {
            return dbset.ToList();//tolist hepsini getirir
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();//sonucu Queryable dir
        }

        public IQueryable<T> GetQueryable()
        {
            return dbset.AsQueryable();
        }

        //public T Update(T item)
        //{
        //    dbset.Update(item);
        //    return item;
        //}

        #endregion

    }
}
