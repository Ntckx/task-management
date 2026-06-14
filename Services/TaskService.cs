using System.Runtime.CompilerServices;
using TaskManagement.DTOs;
using TaskManagement.Factory;
using TaskManagement.Models;
using TaskManagement.Observer;
using TaskManagement.Repository;
using TaskManagement.State;
using TaskManagement.Strategy;

namespace TaskManagement.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ITaskFactoryRegistry _taskFactoryRegistry;
    private readonly IPriorityStrategyRegistry _strategyRegistry;

    private readonly List<ITaskObserver> _observer;

    private readonly TaskStateRestorer _restorer;

    public TaskService(ITaskRepository taskRepository, ITaskFactoryRegistry taskFactoryRegistry, IPriorityStrategyRegistry strategyRegistry, TaskStateRestorer taskStateRestorer, List<ITaskObserver> observers)
    {
        _taskRepository = taskRepository;
        _taskFactoryRegistry = taskFactoryRegistry;
        _strategyRegistry = strategyRegistry;
        _restorer = taskStateRestorer;
        _observer = observers;
    }
    public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto)
    {

        // * Get Task Type from Dto and use GetFactory method from taskFactoryRegistry to create type of that task
        var factory = _taskFactoryRegistry.GetFactory(dto.TaskItemType);

        var task = factory.CreateTask(dto);

        var strategy = _strategyRegistry.GetPriority(dto.TaskItemType);

        var context = new PriorityContext(task);

        task.TaskItemPriority = strategy.CalculatePriority(context);

        var savedTask = await _taskRepository.CreateAsync(task);

        return MapToResponseDto(savedTask);
    }

    public async Task<List<TaskResponseDto>> GetAllTaskAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(MapToResponseDto).ToList();
    }

    public async Task<TaskResponseDto> GetTaskByIdAsync(Guid id)
    {
        var taskItem = await _taskRepository.GetByIdAsync(id);
        return MapToResponseDto(taskItem);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _taskRepository.DeleteByIdAsync(id);
    }

    public async Task<TaskPriority> GetTaskPriorityByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        var strategy = _strategyRegistry.GetPriority(task.TaskItemType);
        var context = new PriorityContext(task);

        return strategy.CalculatePriority(context);

    }

    public async Task<TaskResponseDto> StartTaskByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        var context = new TaskContext(task, _restorer, _observer);

        context.Start();

        var updatedTask = await _taskRepository.UpdateAsync(task);
        return MapToResponseDto(updatedTask);
    }


    private TaskResponseDto MapToResponseDto(TaskItem task)
    {
        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            TaskItemType = task.TaskItemType,
            TaskItemStatus = task.TaskItemStatus,
            TaskPriority = task.TaskItemPriority,
            DueDate = task.DueDate,
            AssigneeId = task.AssigneeId,
        };
    }
}