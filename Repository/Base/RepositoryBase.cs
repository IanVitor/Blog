using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Context;
using Blog.Models;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Base
{
  public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
  {
    public readonly DbSet<TEntity> DbSet;
    public readonly BlogDbContext Context;

    public RepositoryBase(BlogDbContext context)
    {
      DbSet = context.Set<TEntity>();
      Context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
      await DbSet.AddAsync(entity);
      await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll() =>
      await DbSet.ToListAsync();

    public async Task<TEntity> GetPerId(Guid id) =>
      await DbSet.FindAsync(id);

    public async Task UpdateAsync(TEntity entity)
    {
      DbSet.Update(entity);
      await Context.SaveChangesAsync();
    }

    public async Task Remove(Guid id)
    {
      var EntityToRemove = await GetPerId(id);
      DbSet.Remove(EntityToRemove);
      await Context.SaveChangesAsync();
    }
  }
}