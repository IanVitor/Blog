using System;

namespace Blog.Models
{
  public class Entity 
  {
    public Guid Id { get; private set; }

    public Entity(Guid id)
    {
      Id = id;
    }
  }
}