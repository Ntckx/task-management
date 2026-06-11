using TaskManagement.Models;

namespace TaskManagement.Observer;

public class LogObserver : ITaskObserver
{
    // * LogObserver sending log logic about updated status
    public void Update(TaskItem taskItem)
    {
        Console.WriteLine($"[Log] Task: {taskItem.Title} status is updated to {taskItem.TaskItemStatus}");
    }
}