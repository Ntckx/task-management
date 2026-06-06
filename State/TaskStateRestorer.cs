using TaskManagement.Models;

namespace TaskManagement.State;

public class TaskStateRestorer
{
    public object Restore(TaskItemStatus status) => status switch
    {
        TaskItemStatus.TODO => new TodoState(),
        TaskItemStatus.IN_PROGRESS => new InProgressState(),
        TaskItemStatus.REVIEW => new ReviewState(),
        TaskItemStatus.DONE => new DoneState(),
        TaskItemStatus.CANCELLED => new CancelledState(),
        _ => new TodoState()
    };
}