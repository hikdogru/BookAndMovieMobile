using BookAndMovieMobile.Core.Data;
using BookAndMovieMobile.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Data.Concrete.EfCore
{
    public class EfCoreEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        private DbSet<TEntity> Table { get; set; }

        public EfCoreEntityRepositoryBase(TContext context)
        {
            _context = context;
            Table = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? Table.ToList() : Table.Where(expression).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await Table.ToListAsync() : await Table.Where(expression).ToListAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return Table.SingleOrDefault(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.SingleOrDefaultAsync(expression);
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
