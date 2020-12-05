using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private ApplicationDbContext _context;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(long id)
        {
           var entity= _context.Set<T>().FirstOrDefault(x => x.Id == id);
            var res = _context.Remove(entity);
            int result = _context.SaveChanges();
            return result == 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            _context.Set<T>().Remove(entity);
            int result = await _context.SaveChangesAsync();
            return result == 0;
        }

       

        public T Get(long id)
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);

        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetAsync(long id)
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public T Insert(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
            _context.SaveChanges();
            return newEntity;
        }

        public async Task<T> InsertAsync(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        public T Update(T Object)
        {
            _context.Set<T>().Update(Object);
            _context.SaveChanges();
            return Object;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}

