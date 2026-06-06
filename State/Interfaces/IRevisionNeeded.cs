namespace TaskManagement.State;

public interface IRevisionNeeded
{
    public void Revise(TaskContext context);
}