using TaskManagement.Exceptions;
using TaskManagement.Models;

namespace TaskManagement.Strategy;

public class PriorityStrategyRegistry : IPriorityStrategyRegistry
{
    // * Return the given priority calculator for this task type
    // * Used map to store Type as Key, and IPriority as value to provide the priority calculator of the type
    // * Ex) BUG -> bugPriority
    private readonly Dictionary<TaskItemType, IPriority> _strategies;
    public PriorityStrategyRegistry(BugPriority bugPriority, FeaturePriority featurePriority, StoryPriority storyPriority)
    {
        _strategies = new Dictionary<TaskItemType, IPriority>
        {
            {TaskItemType.BUG,bugPriority},
            {TaskItemType.FEATURE,featurePriority},
            {TaskItemType.STORY, storyPriority}
        };
    }

    public IPriority GetPriority(TaskItemType taskItemType)
    {
        return _strategies.TryGetValue(taskItemType, out var strategy) ? strategy
        : throw new BadRequestException($"No strategy for task type {taskItemType}");
    }
}