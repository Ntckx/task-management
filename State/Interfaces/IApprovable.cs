namespace TaskManagement.State;

public interface IApprovable
{
    public void Approve(TaskContext context);
}