using System;
using Blog.Models;

namespace Blog.Repository.Interfaces
{
  public interface IRepositoryBase<TEntity> where TEntity : Entity
  {
    Task<IList<TEntity>> GetAll();
    Task<TEntity> GetPerId(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task Remove(Guid id);
  }
}