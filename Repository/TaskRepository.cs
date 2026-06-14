using Microsoft.EntityFrameworkCore;
using TaskManagement.data;
using TaskManagement.DTOs;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.State;

namespace TaskManagement.Repository;

public class TaskRepository : ITaskRepository
{
    // * C# use EF core from DbContext
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }
    // * Find TaskItem by Id
    public async Task<TaskItem> GetByIdAsync(Guid id)
    {
        return await _context.TaskItems.FindAsync(id)
                ?? throw new NotFoundException($"Task: {id}, cannot be found");
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.ToListAsync()
                ?? throw new NotFoundException($"Cannot find any tasks");
    }

    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        await _context.AddAsync(taskItem);

        await _context.SaveChangesAsync();

        return taskItem;

    }

    public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
    {
        _context.Update(taskItem);
        await _context.SaveChangesAsync();

        return taskItem;
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var getTaskById = await GetByIdAsync(id);

        _context.TaskItems.Remove(getTaskById);

        await _context.SaveChangesAsync();
    }

}