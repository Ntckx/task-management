using TaskManagement.Models;
using TaskManagement.State;

namespace TaskManagement.Strategy;

public class FeaturePriority : IPriority
{
    public TaskPriority CalculatePriority(PriorityContext context)
    {
        if (context.DueDate.Equals(null))
        {
            return TaskPriority.LOW;
        }
        var daysUntilDue = (context.DueDate - DateTime.UtcNow).Value.TotalDays;

        if (daysUntilDue > 3)
        {
            return TaskPriority.LOW;
        }
        else if (daysUntilDue <= 3 && daysUntilDue > 1)
        {
            return TaskPriority.MEDIUM;
        }
        else
        {
            return TaskPriority.HIGH;
        }
    }
}