using TaskManagement.Models;

namespace TaskManagement.Strategy;

public interface IPriorityStrategyRegistry
{
    IPriority GetPriority(TaskItemType taskItemType);
}