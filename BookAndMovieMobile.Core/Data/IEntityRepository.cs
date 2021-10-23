using BookAndMovieMobile.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Core.Data
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll<T>(Expression<Func<T, bool>> expression = null);
        T Get<T>(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


        Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
