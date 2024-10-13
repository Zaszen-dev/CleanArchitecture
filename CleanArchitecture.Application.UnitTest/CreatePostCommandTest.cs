using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handlers;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.Entities;
using Moq;

namespace CleanArchitecture.Application.UnitTest;

public class CreatePostCommandTest
{
    [Fact]
    public async Task GivenCreatePostCommandHandler_WhenHandleCalled_ThenCreateNewPost()
    {
        // Arrange
        var expectedGuid = Guid.NewGuid();
        var toDoRepositoryMock = new Mock<IPostRepository>();
        toDoRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Post>()))
            .ReturnsAsync(expectedGuid);
        var createToDoItemCommandHandler = new CreatePostCommandHandler(toDoRepositoryMock.Object);
        var createToDoItemCommand = new CreatePostCommand
        {
            Title = "Title test",
            Content = "Content test"
        };

        // Act
        var result = await createToDoItemCommandHandler.Handle(createToDoItemCommand, CancellationToken.None);

        // Assert
        Assert.Equal(expectedGuid, result);
    }

    [Fact]
    public async Task GivenPostQueryHandler_WhenHandleCalled_ThenReturnPosts()
    {
        // Arrange
        var expectedPosts = new List<Post>
        {
            new() { Title = "Post 1", Content = "Content 1" },
            new() { Title = "Post 2", Content = "Content 2" }
        };

        var mockRepository = new Mock<IPostRepository>();
        mockRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(expectedPosts);

        var handler = new PostQueryHandler(mockRepository.Object);
        var query = new PostQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(expectedPosts, result);
    }
}