using TaskManagement.Models;

namespace TaskManagement.Repository;

public interface ITaskRepository
{
    Task<TaskItem> GetByIdAsync(Guid id);
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem> CreateAsync(TaskItem taskItem);
    Task<TaskItem> UpdateAsync(TaskItem taskItem);
    Task DeleteByIdAsync(Guid id);
}