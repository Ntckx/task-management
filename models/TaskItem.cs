namespace TaskManagement.Models;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskType TaskItemType { get; set; }
    public TaskStatus TaskItemStatus { get; set; }
    public TaskPriority TaskItemPriority { get; set; }
    public int StoryPoint { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? AssigneeId { get; set; }

    public User? Assignee { get; set; }

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    // No Arg Constructor
    public TaskItem()
    {

    }

    public TaskItem(
        string title,
        string? description,
        TaskType taskItemType,
        TaskStatus taskItemStatus,
        TaskPriority taskItemPriority,
        int storyPoint,
        DateTime dueDate,
        Guid? assigneeId
    )
    {
        Title = title;
        Description = description;
        TaskItemType = taskItemType;
        TaskItemStatus = taskItemStatus;
        TaskItemPriority = taskItemPriority;
        StoryPoint = storyPoint;
        DueDate = dueDate;
        AssigneeId = assigneeId;
    }


}