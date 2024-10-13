using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application;

/// <summary>
/// Represents a repository for managing posts.
/// </summary>
public interface IPostRepository
{
    /// <summary>
    /// Retrieves all posts from the repository.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of posts.</returns>
    Task<List<Post>> GetAllAsync();

    /// <summary>
    /// Retrieves a post by its ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the post with the specified ID, or null if no post is found.</returns>
    Task<Post> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new post to the repository.
    /// </summary>
    /// <param name="post">The post to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the added post.</returns>
    Task<Guid> AddAsync(Post post);
}