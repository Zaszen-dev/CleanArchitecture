using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repositories;

public class InMemoryPostRepository : IPostRepository
{
    private static readonly List<Post> _items = [];
    public Task<Guid> AddAsync(Post post)
    {
        _items.Add(post);
        return Task.FromResult(post.Id);
    }

    public Task<List<Post>> GetAllAsync()
    {
        return Task.FromResult(_items);
    }

    public Task<Post> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
