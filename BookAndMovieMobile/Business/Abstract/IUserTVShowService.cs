using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Business.Abstract
{
    public interface IUserTVShowService
    {
        UserTVShow Get(Expression<Func<UserTVShow, bool>> filter);
        List<UserTVShow> GetAll(Expression<Func<UserTVShow, bool>> filter = null);
        void Add(UserTVShow entity);
        void Delete(UserTVShow entity);
        void Update(UserTVShow entity);


        Task<UserTVShow> GetAsync(Expression<Func<UserTVShow, bool>> filter);
        Task<List<UserTVShow>> GetAllAsync(Expression<Func<UserTVShow, bool>> filter = null);
        Task AddAsync(UserTVShow entity);
        Task DeleteAsync(UserTVShow entity);
        Task UpdateAsync(UserTVShow entity);
    }
}
