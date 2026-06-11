using TaskManagement.Models;
using TaskManagement.Exceptions;
using TaskManagement.Observer;

namespace TaskManagement.State;

public class TaskContext
{
    private object _currentState;
    private readonly TaskStateRestorer _restorer;

    // * Observer, Added a list field to add ITaskObserver object, make it readonly so that it cannot be reassign
    private readonly List<ITaskObserver> _observers;

    // * Subscribe method that add ITaskObserver object to the list
    public void Subscribe(ITaskObserver taskObserver)
    {
        _observers.Add(taskObserver);
    }


    // * Notify observer, loop that go through all item in _observers and call Update method for each
    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(Task);
        }
    }


    public TaskItem Task
    { get; }
    public TaskContext(TaskItem task, TaskStateRestorer restorer, List<ITaskObserver> observers)
    {
        Task = task;
        _restorer = restorer;
        _currentState = _restorer.Restore(task.TaskItemStatus);
        _observers = observers;
    }
    public void ChangeState(object newState)
    {
        _currentState = newState;
    }


    public void Start()
    {
        if (_currentState is IStartable s)
        {
            s.Start(this);
            NotifyObservers();
        }
        else
            throw new InvalidStateTransitionException(
                $"Cannot start from {Task.TaskItemStatus}");
    }

    public void Submit()
    {
        if (_currentState is ISubmittable s)
        {
            s.Submit(this);
            NotifyObservers();
        }
        else
            throw new InvalidStateTransitionException(
                $"Cannot submit from {Task.TaskItemStatus}");
    }

    public void Approve()
    {
        if (_currentState is IApprovable s)
        {
            s.Approve(this);
            NotifyObservers();
        }
        else
            throw new InvalidStateTransitionException(
                $"Cannot approve from {Task.TaskItemStatus}");
    }

    public void Cancel()
    {
        if (_currentState is ICancellable s)
        {
            s.Cancel(this);
            NotifyObservers();
        }
        else
            throw new InvalidStateTransitionException(
                $"Cannot cancel from {Task.TaskItemStatus}");
    }
}