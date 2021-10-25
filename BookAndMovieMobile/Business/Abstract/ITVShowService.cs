using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Business.Abstract
{
    public interface ITVShowService
    {
        TVShow Get(Expression<Func<TVShow, bool>> filter);
        List<TVShow> GetAll(Expression<Func<TVShow, bool>> filter = null);
        void Add(TVShow entity);
        void Delete(TVShow entity);
        void Update(TVShow entity);
        bool IsTVShowExistInDatabase(TVShow entity, int databaseSaveType);

        Task<TVShow> GetAsync(Expression<Func<TVShow, bool>> filter);
        Task<List<TVShow>> GetAllAsync(Expression<Func<TVShow, bool>> filter = null);
        Task AddAsync(TVShow entity);
        Task DeleteAsync(TVShow entity);
        Task UpdateAsync(TVShow entity);
        Task<bool> IsTVShowExistInDatabaseAsync(TVShow entity, int databaseSaveType);

    }
}
