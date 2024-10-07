using System;
using System.Collections.Generic;

namespace FamilyApp.Interfaces
{
    public partial interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Find(Func<T, bool> predicate);

        void Add(T entity);
        void Add(IEnumerable<T> entities);

        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
    }
}