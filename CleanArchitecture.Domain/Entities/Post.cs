namespace CleanArchitecture.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}
