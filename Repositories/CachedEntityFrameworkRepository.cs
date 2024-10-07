using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FamilyApp.Data;
using FamilyApp.Interfaces;

namespace FamilyApp.Repositories
{

    public abstract partial class CachedEntityFrameworkRepository<T> : IRepository<T> where T : class
    {

        protected internal FamilyAppEntities Context;
        protected internal List<T> Cache;

        public CachedEntityFrameworkRepository(FamilyAppEntities MyContext)
        {
            Context = MyContext;
            Cache = Context.Set<T>().ToList();
            if (Cache is null)
            {
                Cache = new List<T>();
            }
        }

        public void Add(T entity)
        {
            if (entity is null)
            {
                return;
            }
            Context.Set<T>().Add(entity);
            Cache.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                return;
            }
            Context.Set<T>().AddRange(entities);
            Cache.AddRange(entities);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Cache.Where(predicate);
        }

        public IEnumerable<T> Get()
        {
            return Cache;
        }

        public void Remove(T entity)
        {
            if (entity is null)
            {
                return;
            }
            Context.Set<T>().Remove(entity);
            Cache.Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                return;
            }
            Context.Set<T>().RemoveRange(entities);
            foreach (T entity in entities)
                Cache.Remove(entity);
        }
    }
}