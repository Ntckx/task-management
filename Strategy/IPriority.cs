using TaskManagement.Models;
using TaskManagement.State;

namespace TaskManagement.Strategy;

public interface IPriority
{
    TaskPriority CalculatePriority(PriorityContext context);
}