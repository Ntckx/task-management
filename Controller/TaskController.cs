using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controller;

[ApiController]
[Route("/api/task")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> CreateTask(CreateTaskDto dto)
    {
        var result = await _taskService.CreateTaskAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskResponseDto>>> GetAllTask()
    {
        var result = await _taskService.GetAllTaskAsync();
        return Ok(result);
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<TaskResponseDto>> GetTaskById(Guid id)
    {
        var result = await _taskService.GetTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("/{id}/task-priority")]
    public async Task<ActionResult<TaskPriority>> GetTaskPriorityById(Guid id)
    {
        var result = await _taskService.GetTaskPriorityByIdAsync(id);
        return Ok(result);
    }


    [HttpDelete("/{id}")]
    public async Task<ActionResult> DeleteTaskById(Guid id)
    {
        await _taskService.DeleteByIdAsync(id);
        return NoContent();
    }

    [HttpPut("/{id}/start-task")]
    public async Task<ActionResult<TaskResponseDto>> StartTaskById(Guid id)
    {
        var result = await _taskService.StartTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("/{id}/submit-task")]
    public async Task<ActionResult<TaskResponseDto>> SubmitTaskById(Guid id)
    {
        var result = await _taskService.SubmitTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("/{id}/approve-task")]
    public async Task<ActionResult<TaskResponseDto>> ApproveTaskById(Guid id)
    {
        var result = await _taskService.ApproveTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("/{id}/cancel-task")]
    public async Task<ActionResult<TaskResponseDto>> CancelTaskById(Guid id)
    {
        var result = await _taskService.CancelTaskByIdAsync(id);
        return Ok(result);
    }



}