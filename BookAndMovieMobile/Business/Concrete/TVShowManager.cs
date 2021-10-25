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
    public class TVShowManager : ITVShowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TVShowManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public void Add(TVShow entity)
        {
            if (IsTVShowExistInDatabase(entity: entity, databaseSaveType: entity.DatabaseSavingType) == false)
            {
                _unitOfWork.TVShows.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(TVShow entity)
        {
            if (await IsTVShowExistInDatabaseAsync(entity: entity, databaseSaveType: entity.DatabaseSavingType) == false)
            {
                await _unitOfWork.TVShows.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(TVShow entity)
        {
            _unitOfWork.TVShows.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task DeleteAsync(TVShow entity)
        {
            await _unitOfWork.TVShows.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<TVShow> GetAll(Expression<Func<TVShow, bool>> filter = null)
        {
            return filter == null ? _unitOfWork.TVShows.GetAll() : _unitOfWork.TVShows.GetAll(filter);
        }

        public async Task<List<TVShow>> GetAllAsync(Expression<Func<TVShow, bool>> filter = null)
        {
            return filter == null ? await _unitOfWork.TVShows.GetAllAsync() : await _unitOfWork.TVShows.GetAllAsync(filter);
        }

        public TVShow Get(Expression<Func<TVShow, bool>> filter)
        {
            return _unitOfWork.TVShows.Get(filter);
        }

        public async Task<TVShow> GetAsync(Expression<Func<TVShow, bool>> filter)
        {
            return await _unitOfWork.TVShows.GetAsync(filter);
        }

        public bool IsTVShowExistInDatabase(TVShow entity, int databaseSaveType)
        {
            var isExist = GetAll(x => x.BackdropPath == entity.BackdropPath && x.DatabaseSavingType == databaseSaveType);
            return isExist.Count == 0 ? false : true;
        }

        public async Task<bool> IsTVShowExistInDatabaseAsync(TVShow entity, int databaseSaveType)
        {
            var isExist = await GetAllAsync(x => x.BackdropPath == entity.BackdropPath && x.DatabaseSavingType == databaseSaveType);
            if (entity.Id != 0)
            {
                isExist = GetAll(x => x.Id == entity.Id);
            }
            return isExist.Count == 0 ? false : true;
        }

        public void Update(TVShow entity)
        {
            bool isTVShowExist = IsTVShowExistInDatabase(entity: entity, databaseSaveType: entity.DatabaseSavingType);
            if (isTVShowExist == false)
            {
                _unitOfWork.TVShows.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(TVShow entity)
        {
            bool isTVShowExist = await IsTVShowExistInDatabaseAsync(entity: entity, databaseSaveType: entity.DatabaseSavingType);
            if (isTVShowExist == false)
            {
                await _unitOfWork.TVShows.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
