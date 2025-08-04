using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories;
using TaskFlow.Api.Services;
using Moq;

namespace TaskFlow.Tests;

public class TaskServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllTasks()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<TaskItem> {
            new TaskItem { Id = 1, Title = "Test 1" },
            new TaskItem { Id = 2, Title = "Test 2" }
        });
        var service = new TaskService(mockRepo.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }
} 