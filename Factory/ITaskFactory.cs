using TaskManagement.DTOs;
using TaskManagement.Models;

namespace TaskManagement.Factory;

public interface ITaskFactory
{
    TaskItem CreateTask(CreateTaskDto dto);
}