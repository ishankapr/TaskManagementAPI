using TaskManagement.Entities;
using TodoTask = TaskManagement.Entities.TodoTask;

namespace TaskManagement.Services

{
    public interface ITaskService
    {
        public Task<TodoTask> CreateTaskAsync(TodoTask task);
        public Task<List<TodoTask>> GetAllTasksAsync();
        public Task<TodoTask> GetTaskByIdAsync(int taskId);
        public Task<TodoTask> DeleteTaskByIdAsync(int taskId);
        public Task<TodoTask> UpdateTaskAsync(TodoTask task);
        public Task<bool> MarkAsCompleted(int id);
    }
}
