using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManagement;
using TaskManagement.Entities;
using TaskManagement.Services;

namespace TaskTests
{
    public class TaskServiceTests : IDisposable
    {
        protected readonly TaskDbContext _context;
        protected readonly TaskService _taskService;

        TodoTask task = new TodoTask()
        {
            Description = "Test Task 1",
            Title = "Test Title",
            DueDate = DateTime.Now.AddMonths(1),
            TaskID = 1,
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        };

        public TaskServiceTests()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

                _context = new TaskDbContext(options);
                _context.Database.EnsureCreated();

            _taskService = new TaskService(_context);
        }

        [Fact]
        public async Task Create_TasK_And_Check_Result_Success()
        {
            ///// Arrange
            
            ///// Act
            var result = await _taskService.CreateTaskAsync(task);

            /// Assert
            Assert.NotNull(result);
            Assert.Equal(1,result.TaskID);
            Assert.Equal("Test Task 1", result.Description);
        }

        [Fact]
        public async Task Get_All_Tasks_Created_Success()
        {
            ///// Arrange

            await _taskService.CreateTaskAsync(task);

            ///// Act
            var result = await _taskService.GetAllTasksAsync();

            /// Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateTask_ShouldModifyTaskDescriptionAsync()
        {
            ///// Arrange
            await _taskService.CreateTaskAsync(task);

            ///// Act

            task.Description = "Test Task 1 Updated";
            var result = await _taskService.UpdateTaskAsync(task);

            /// Assert

            Assert.NotNull(result);
            Assert.Equal("Test Task 1 Updated", task.Description);
        }

        [Fact]
        public async Task DeleteTask_ShouldRemoveTaskFromListAsync()
        {
            ///// Arrange
            await _taskService.CreateTaskAsync(task);

            ///// Act

            await _taskService.DeleteTaskByIdAsync(1);
            var result = _taskService.GetAllTasksAsync();
            /// Assert

            Assert.Empty(result.Result);
        }

        [Fact]
        public async Task MarkAsComplete_Task_Should_Update_Status()
        {
            ///// Arrange
            await _taskService.CreateTaskAsync(task);

            ///// Act

            await _taskService.MarkAsCompleted(1);
            var result = _taskService.GetTaskByIdAsync(1);
            /// Assert

            Assert.True(result.Result.IsCompleted);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}
