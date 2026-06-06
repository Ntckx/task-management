namespace TaskManagement.State;

public interface ISubmittable
{
    public void Submit(TaskContext context);
}