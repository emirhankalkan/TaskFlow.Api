using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories;
using TaskFlow.Api.Services;
using Moq;
using Xunit;

namespace TaskFlow.Tests;

public class TaskServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllTasks()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var expectedTasks = new List<TaskItem> 
        {
            new TaskItem { Id = 1, Title = "Test 1" },
            new TaskItem { Id = 2, Title = "Test 2" }
        };
        
        mockRepo.Setup(r => r.GetAllAsync())
               .ReturnsAsync(expectedTasks);
        
        var service = new TaskService(mockRepo.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Test 1", result.First().Title);
        Assert.Equal("Test 2", result.Last().Title);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var expectedTask = new TaskItem { Id = 1, Title = "Test Task" };
        
        mockRepo.Setup(r => r.GetByIdAsync(1))
               .ReturnsAsync(expectedTask);
        
        var service = new TaskService(mockRepo.Object);

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test Task", result.Title);
    }

    [Fact]
    public async Task CreateAsync_CallsRepositoryCreateAsync()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var newTask = new TaskItem { Title = "New Task" };
        var createdTask = new TaskItem { Id = 1, Title = "New Task" };
        
        mockRepo.Setup(r => r.CreateAsync(newTask))
               .ReturnsAsync(createdTask);
        
        var service = new TaskService(mockRepo.Object);

        // Act
        var result = await service.CreateAsync(newTask);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("New Task", result.Title);
        mockRepo.Verify(r => r.CreateAsync(newTask), Times.Once);
    }
}