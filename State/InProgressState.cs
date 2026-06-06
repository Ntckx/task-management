namespace TaskManagement.State;

public class InProgressState : ISubmittable, ICancellable
{
    public void Submit(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.REVIEW;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new ReviewState());
    }
    public void Cancel(TaskContext context)
    {
        context.Task.TaskItemStatus = Models.TaskItemStatus.CANCELLED;
        context.Task.UpdatedAt = DateTime.UtcNow;
        context.ChangeState(new CancelledState());
    }
}