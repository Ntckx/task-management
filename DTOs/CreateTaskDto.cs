using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

namespace TaskManagement.DTOs;

public class CreateTaskDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public TaskItemType TaskItemType { get; set; }

    public int? StoryPoint { get; set; }

    public DateTime? DueDate { get; set; }

    public Guid? AssigneeId { get; set; }
}