namespace TaskManagement.State;

public interface ICancellable
{
    public void Cancel(TaskContext context);
}