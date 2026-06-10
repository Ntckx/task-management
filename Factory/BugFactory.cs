using TaskManagement.DTOs;
using TaskManagement.Exceptions;
using TaskManagement.Models;

namespace TaskManagement.Factory;

public class BugFactory : ITaskFactory
{
    public TaskItem CreateTask(CreateTaskDto dto)
    {
        if (dto.StoryPoint == null)
            throw new BadRequestException("Bug requires story points");
        return new TaskItem(
            title: $"[BUG] {dto.Title}",
            description: dto.Description,
            taskItemType: dto.TaskItemType,
            storyPoint: dto.StoryPoint,
            dueDate: dto.DueDate,
            assigneeId: dto.AssigneeId
        );
    }
}