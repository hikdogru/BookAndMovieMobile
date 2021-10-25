using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BooksAndMovies.Entity;

namespace BookAndMovieMobile.Business.Abstract
{
    public interface IMovieService
    {
        Movie Get(Expression<Func<Movie, bool>> filter);
        List<Movie> GetAll(Expression<Func<Movie, bool>> filter = null);
        void Add(Movie entity);
        void Delete(Movie entity);
        void Update(Movie entity);
        bool IsMovieExistInDatabase(Movie entity, int databaseSaveType);


        Task<Movie> GetAsync(Expression<Func<Movie, bool>> filter);
        Task<List<Movie>> GetAllAsync(Expression<Func<Movie, bool>> filter = null);
        Task AddAsync(Movie entity);
        Task DeleteAsync(Movie entity);
        Task UpdateAsync(Movie entity);
        Task<bool> IsMovieExistInDatabaseAsync(Movie entity, int databaseSaveType);

    }
}
