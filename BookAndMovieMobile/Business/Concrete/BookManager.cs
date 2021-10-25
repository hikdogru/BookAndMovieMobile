﻿using BookAndMovieMobile.Business.Abstract;
using BooksAndMovies.Business.Concrete;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BooksAndMovies.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public void Add(Book entity)
        {
            if (IsBookExistInDatabase(entity: entity, databaseSaveType: entity.DatabaseSavingType) == false)
            {
                _bookRepository.Add(entity);
                
            }
        }

        public async Task AddAsync(Book entity)
        {
            if (await IsBookExistInDatabaseAsync(entity: entity, databaseSaveType: entity.DatabaseSavingType) == false)
            {
                await _bookRepository.AddAsync(entity);
            }
        }

        public void Delete(Book entity)
        {
            _bookRepository.Delete(entity);
            
        }

        public async Task DeleteAsync(Book entity)
        {
            await _bookRepository.DeleteAsync(entity);
            
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            return filter == null ? _bookRepository.GetAll() : _bookRepository.GetAll(filter);
        }

        public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>> filter = null)
        {
            return filter == null ? await _bookRepository.GetAllAsync() : await _bookRepository.GetAllAsync(filter);
        }

        public Book Get(Expression<Func<Book, bool>> filter)
        {
            return _bookRepository.Get(filter);
        }

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> filter)
        {
            return await _bookRepository.GetAsync(filter);
        }

        public bool IsBookExistInDatabase(Book entity, int databaseSaveType)
        {
            var isExist = GetAll(x => x.Thumbnail == entity.Thumbnail && x.DatabaseSavingType == databaseSaveType);
            return isExist.Count == 0 ? false : true;
        }

        public async Task<bool> IsBookExistInDatabaseAsync(Book entity, int databaseSaveType)
        {
            var isExist = await GetAllAsync(x => x.Thumbnail == entity.Thumbnail && x.DatabaseSavingType == databaseSaveType);
            return isExist.Count == 0 ? false : true;
        }

        public void Update(Book entity)
        {
            bool isBookExist = IsBookExistInDatabase(entity: entity, databaseSaveType: entity.DatabaseSavingType);
            if (isBookExist == false)
            {
                _bookRepository.Update(entity);
                
            }

        }

        public async Task UpdateAsync(Book entity)
        {
            bool isBookExist = await IsBookExistInDatabaseAsync(entity: entity, databaseSaveType: entity.DatabaseSavingType);
            if (isBookExist == false)
            {
                await _bookRepository.UpdateAsync(entity);
                
            }
        }
    }
}