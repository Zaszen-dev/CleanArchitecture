
using MediatR;

namespace CleanArchitecture.Application.Commands;

public class CreatePostCommand: IRequest<Guid>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}
