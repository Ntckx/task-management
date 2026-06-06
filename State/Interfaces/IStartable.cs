namespace TaskManagement.State;

public interface IStartable
{
    public void Start(TaskContext context);
}