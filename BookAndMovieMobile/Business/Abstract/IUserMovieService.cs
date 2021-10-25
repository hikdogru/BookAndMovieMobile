using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Business.Abstract
{
    public interface IUserMovieService
    {
        UserMovie Get(Expression<Func<UserMovie, bool>> filter);
        List<UserMovie> GetAll(Expression<Func<UserMovie, bool>> filter = null);
        void Add(UserMovie entity);
        void Delete(UserMovie entity);
        void Update(UserMovie entity);


        Task<UserMovie> GetAsync(Expression<Func<UserMovie, bool>> filter);
        Task<List<UserMovie>> GetAllAsync(Expression<Func<UserMovie, bool>> filter = null);
        Task AddAsync(UserMovie entity);
        Task DeleteAsync(UserMovie entity);
        Task UpdateAsync(UserMovie entity);
    }
}
