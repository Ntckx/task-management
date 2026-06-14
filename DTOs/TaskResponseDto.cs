using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

namespace TaskManagement.DTOs;

public class TaskResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public TaskItemType TaskItemType { get; set; }
    public TaskItemStatus TaskItemStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }
    public int? StoryPoint { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid? AssigneeId { get; set; }
}