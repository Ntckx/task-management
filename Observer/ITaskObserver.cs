using TaskManagement.Models;

namespace TaskManagement.Observer;

// * Define a contract for all task observers to receive state update notifications
public interface ITaskObserver
{
    public void Update(TaskItem taskItem);
}