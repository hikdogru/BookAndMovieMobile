﻿using BooksAndMovies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Business.Abstract
{
    public interface IUserService
    {
        User Get(Expression<Func<User, bool>> filter);
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        void Add(User entity);
        void Delete(User entity);
        void Update(User entity);
        bool IsUserExistInDatabase(User entity);


        Task<User> GetAsync(Expression<Func<User, bool>> filter);
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task AddAsync(User entity);
        Task DeleteAsync(User entity);
        Task UpdateAsync(User entity);
        Task<bool> IsUserExistInDatabaseAsync(User entity);
    }
}
