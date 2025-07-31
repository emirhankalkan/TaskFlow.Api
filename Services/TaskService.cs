using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories;

namespace TaskFlow.Api.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TaskItem>> GetAllAsync() => _repository.GetAllAsync();
    public Task<TaskItem?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
    public Task<TaskItem> AddAsync(TaskItem task) => _repository.AddAsync(task);
    public Task<bool> UpdateAsync(TaskItem task) => _repository.UpdateAsync(task);
    public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
} 