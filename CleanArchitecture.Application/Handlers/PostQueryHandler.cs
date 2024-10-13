using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers;

public class PostQueryHandler(IPostRepository postRepository)
    : IRequestHandler<PostQuery, List<Post>>
{
    public Task<List<Post>> Handle(PostQuery request, CancellationToken cancellationToken)
    {
        return postRepository.GetAllAsync();
    }
}