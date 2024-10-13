
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers;

public class CreatePostCommandHandler(IPostRepository postRepository)
    : IRequestHandler<CreatePostCommand, Guid>
{
    /// <summary>
    /// Handles the creation of a new post.
    /// </summary>
    /// <param name="request">The create post command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous creation of a post.</returns>
    public Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content
        };
        return postRepository.AddAsync(post);
    }
}
