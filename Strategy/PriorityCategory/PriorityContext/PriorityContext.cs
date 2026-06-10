using TaskManagement.Models;

namespace TaskManagement.State;

// TODO Create a custome PriorityContext to be used as argument for calculating different priority strategies
// * We Use get; in PriorityContext to controll access level to read- only
public class PriorityContext
{
    public int? StoryPoint { get; }
    public DateTime? DueDate { get; }
    public TaskItemType TaskItemType { get; }

    public PriorityContext(
        TaskItem taskItem
    )
    {
        StoryPoint = taskItem.StoryPoint;
        DueDate = taskItem.DueDate;
        TaskItemType = taskItem.TaskItemType;
    }
}