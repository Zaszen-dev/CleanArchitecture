
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers;

public class CreatePostCommandHandler(IPostRepository postRepository)
    : IRequestHandler<CreatePostCommand, Guid>
{
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
