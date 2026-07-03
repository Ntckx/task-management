namespace TaskManagement.State;

public class ReviewState : IRevisionNeeded, ICancellable, IApprovable
{
    public void Approve(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.DONE;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new DoneState());
    }
    public void Revise(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.TODO;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new TodoState());
    }
    public void Cancel(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.CANCELLED;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new CancelledState());
    }
}