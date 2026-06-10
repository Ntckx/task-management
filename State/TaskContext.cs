using TaskManagement.Models;
using TaskManagement.Exceptions;

namespace TaskManagement.State;

public class TaskContext
{
    private object _currentState;
    private readonly TaskStateRestorer _restorer;
    public TaskItem Task { get; }
    public TaskContext(TaskItem task, TaskStateRestorer restorer)
    {
        Task = task;
        _restorer = restorer;
        _currentState = _restorer.Restore(task.TaskItemStatus);
    }
    public void ChangeState(object newState)
    {
        _currentState = newState;
    }


    public void Start()
    {
        if (_currentState is IStartable s)
            s.Start(this);
        else
            throw new InvalidStateTransitionException(
                $"Cannot start from {Task.TaskItemStatus}");
    }

    public void Submit()
    {
        if (_currentState is ISubmittable s)
            s.Submit(this);
        else
            throw new InvalidStateTransitionException(
                $"Cannot submit from {Task.TaskItemStatus}");
    }

    public void Approve()
    {
        if (_currentState is IApprovable s)
            s.Approve(this);
        else
            throw new InvalidStateTransitionException(
                $"Cannot approve from {Task.TaskItemStatus}");
    }

    public void Cancel()
    {
        if (_currentState is ICancellable s)
            s.Cancel(this);
        else
            throw new InvalidStateTransitionException(
                $"Cannot cancel from {Task.TaskItemStatus}");
    }
}