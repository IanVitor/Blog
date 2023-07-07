using Blog.Context;
using Blog.Models;
using Blog.Repository.Base;
using Blog.Repository.Interfaces;

namespace Blog.Repository
{
  public class PostRepository : RepositoryBase<Post>, IPostRepository
  {
    public PostRepository(BlogDbContext context) : base(context)
    {
    }
  }
}