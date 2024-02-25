using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagement.CustomExceptions;
using TaskManagement.Entities;
using TodoTask = TaskManagement.Entities.TodoTask;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _taskDbContext;
        public TaskService(TaskDbContext taskDbContext) 
        {
            _taskDbContext = taskDbContext;
        }

        public async Task<TodoTask> CreateTaskAsync(TodoTask task)
        {

            await _taskDbContext.Tasks.AddAsync(task);
            await _taskDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<List<TodoTask>> GetAllTasksAsync()
        {
            return await _taskDbContext.Tasks.ToListAsync();
        }

        public async Task<TodoTask> GetTaskByIdAsync(int taskId)
        {
            var task = await _taskDbContext.Tasks.FindAsync(taskId);
            return task;
        }

        public async Task<TodoTask> UpdateTaskAsync(TodoTask task)
        {
            _taskDbContext.Update(task);
            await _taskDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TodoTask> DeleteTaskByIdAsync(int taskId)
        {
            if (taskId <= 0)
            {
                throw new InvalidRequestException("record should be available for update");
            }

            var task = await _taskDbContext.Tasks.FindAsync(taskId);
            _taskDbContext.Tasks.Remove(task);
            await _taskDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> MarkAsCompleted(int id)
        {
            var task = await _taskDbContext.Tasks.FindAsync(id);

            if(task != null)
            {
                task.IsCompleted = true;
                await _taskDbContext.SaveChangesAsync();
                return true;
            }
            
            return false;
        }
    }
}
