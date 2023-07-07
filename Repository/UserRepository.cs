using System;
using Blog.Context;
using Blog.Models;
using Blog.Repository.Base;
using Blog.Repository.Interfaces;

namespace Blog.Repository
{
  public class UserRepository : RepositoryBase<User>, IUserRepository
  {
    public UserRepository(BlogDbContext context) : base(context)
    {
    }
  }
}