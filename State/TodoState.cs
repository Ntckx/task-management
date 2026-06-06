
namespace TaskManagement.State;

public class TodoState : IStartable, ICancellable
{
    public void Start(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.IN_PROGRESS;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new InProgressState());

    }

    public void Cancel(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.CANCELLED;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new CancelledState());
    }
}