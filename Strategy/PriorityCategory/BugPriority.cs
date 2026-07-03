using TaskManagement.Models;
using TaskManagement.State;

namespace TaskManagement.Strategy;

public class BugPriority : IPriority
{
    public TaskPriority CalculatePriority(PriorityContext context)
    {
        if (context.StoryPoint == null)
            return TaskPriority.LOW;
        double? storyScore = context.StoryPoint * 1.5;
        if (storyScore < 5)
        {
            return TaskPriority.LOW;
        }
        else if (storyScore < 7.5 && storyScore > 5)
        {
            return TaskPriority.MEDIUM;
        }
        else
        {
            return TaskPriority.HIGH;
        }

    }
}