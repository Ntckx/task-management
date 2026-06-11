using TaskManagement.Exceptions;
using TaskManagement.Models;

namespace TaskManagement.Factory;

public class TaskFactoryRegistry : ITaskFactoryRegistry
{

    // Use Map to store TaskItemType with Their CreateTask Interface
    private readonly Dictionary<TaskItemType, ITaskFactory> _factories;

    // public TaskFactoryRegistry()
    // {
    //     _factories = new Dictionary<TaskItemType, ITaskFactory>
    //     {
    //         {TaskItemType.BUG, new BugFactory()},
    //         {TaskItemType.FEATURE, new FeatureFactory()},
    //         {TaskItemType.STORY, new StoryFactory()},
    //     };
    // }

    // Inject arguments to Constructor
    public TaskFactoryRegistry(BugFactory bugFactory, FeatureFactory featureFactory, StoryFactory storyFactory)
    {
        _factories = new Dictionary<TaskItemType, ITaskFactory>
        {
            {TaskItemType.BUG, bugFactory},
            {TaskItemType.FEATURE, featureFactory},
            {TaskItemType.STORY, storyFactory}
        };
    }

    public ITaskFactory GetFactory(TaskItemType taskItemType)
    {
        return _factories.TryGetValue(taskItemType, out var factory) ? factory
            : throw new BadRequestException($"No Factory for Task Type {taskItemType}");

    }

}