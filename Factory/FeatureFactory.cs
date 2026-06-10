using TaskManagement.DTOs;
using TaskManagement.Exceptions;
using TaskManagement.Models;

namespace TaskManagement.Factory;

public class FeatureFactory : ITaskFactory
{
    public TaskItem CreateTask(CreateTaskDto dto)
    {
        if (dto.DueDate == null)
        {
            throw new BadRequestException("Feature requires Due Date");
        }
        return new TaskItem(
            title: $"[FEATURE] {dto.Title}",
            description: dto.Description,
            taskItemType: dto.TaskItemType,
            storyPoint: dto.StoryPoint,
            dueDate: dto.DueDate,
            assigneeId: dto.AssigneeId
        );
    }
}