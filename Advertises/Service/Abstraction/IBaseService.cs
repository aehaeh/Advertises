using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public interface IBaseService<T> where T:BaseEntity
    {
        T Get(long id);
        Task<T> GetAsync(long id);


        Task<T> InsertAsync(T newEntity);
        T Insert(T newEntity);


        Task<T> UpdateAsync(T entity);
        T Update(T Object);


        Task<bool> DeleteAsync(long id);
        bool Delete(long id);

        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
    }
}
