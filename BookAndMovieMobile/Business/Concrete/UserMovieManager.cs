using BookAndMovieMobile.Business.Abstract;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndMovies.Business.Concrete
{
    public class UserMovieManager : IUserMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserMovieManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public void Add(UserMovie entity)
        {
            _unitOfWork.UserMovies.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task AddAsync(UserMovie entity)
        {
            await _unitOfWork.UserMovies.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

        }

        public void Delete(UserMovie entity)
        {
            _unitOfWork.UserMovies.Delete(entity);
            _unitOfWork.SaveChanges();

        }

        public async Task DeleteAsync(UserMovie entity)
        {
            await _unitOfWork.UserMovies.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();

        }

        public List<UserMovie> GetAll(Expression<Func<UserMovie, bool>> filter = null)
        {
            return filter == null ? _unitOfWork.UserMovies.GetAll() : _unitOfWork.UserMovies.GetAll(filter);
        }

        public async Task<List<UserMovie>> GetAllAsync(Expression<Func<UserMovie, bool>> filter = null)
        {
            return filter == null ? await _unitOfWork.UserMovies.GetAllAsync() : await _unitOfWork.UserMovies.GetAllAsync(filter);
        }

        public UserMovie Get(Expression<Func<UserMovie, bool>> filter)
        {
            var UserMovie = _unitOfWork.UserMovies.Get(filter);
            return UserMovie;
        }

        public async Task<UserMovie> GetAsync(Expression<Func<UserMovie, bool>> filter)
        {
            var UserMovie = await _unitOfWork.UserMovies.GetAsync(filter);
            return UserMovie;
        }


        public void Update(UserMovie entity)
        {
            _unitOfWork.UserMovies.Update(entity);
            _unitOfWork.SaveChanges();

        }

        public async Task UpdateAsync(UserMovie entity)
        {
            await _unitOfWork.UserMovies.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
