using TaskManagement.Models;

namespace TaskManagement.Factory;

public interface ITaskFactoryRegistry
{
    ITaskFactory GetFactory(TaskItemType taskItemType);
}