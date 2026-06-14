using TaskManagement.DTOs;
using TaskManagement.Models;

namespace TaskManagement.Services;

public interface ITaskService
{
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto);
    Task<List<TaskResponseDto>> GetAllTaskAsync();
    Task<TaskResponseDto> GetTaskByIdAsync(Guid id);
    Task<TaskPriority> GetTaskPriorityByIdAsync(Guid id);
    Task<TaskResponseDto> StartTaskByIdAsync(Guid id);
    Task<TaskResponseDto> SubmitTaskByIdAsync(Guid id);
    Task<TaskResponseDto> ApproveTaskByIdAsync(Guid id);

    Task<TaskResponseDto> CancelTaskByIdAsync(Guid id);
    Task DeleteByIdAsync(Guid id);

}