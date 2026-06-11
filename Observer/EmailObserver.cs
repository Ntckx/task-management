using TaskManagement.Models;

namespace TaskManagement.Observer;

// * Email notification logic when the task status is updated
public class EmailObserver : ITaskObserver
{
    public void Update(TaskItem taskItem)
    {
        // * Email Notification Sending Simulation
        Console.Write($"[Email] Sending to {taskItem.AssigneeId}, Task Title: {taskItem.Title}");
    }
}