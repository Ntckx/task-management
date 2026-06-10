using TaskManagement.Models;
using TaskManagement.State;

namespace TaskManagement.Strategy;

public class StoryPriority : IPriority
{
    // * Story Priority based on story points
    // * 1.2 is used for calculating Story Priority ensure it is less urgent than Bug Task
    public TaskPriority CalculatePriority(PriorityContext context)
    {
        if (context.StoryPoint == null)
            return TaskPriority.LOW;

        // TODO: In future considered making multiplier more configurable
        double? storyScore = context.StoryPoint * 1.2;
        if (storyScore < 5)
        {
            return TaskPriority.LOW;
        }
        else if (storyScore < 7.5)
        {
            return TaskPriority.MEDIUM;
        }
        else
        {
            return TaskPriority.HIGH;
        }
    }
}