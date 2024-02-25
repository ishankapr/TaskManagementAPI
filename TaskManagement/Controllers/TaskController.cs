using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Services;
using TaskManagement.CustomExceptions;
using TaskManagement.Entities;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService) 
        { 
            _taskService = taskService;
        }

        [Route("tasks")]
        [HttpPost]
        public async Task<IActionResult> CreateTask(TodoTask task)
        {
            try
            {
                var response = await _taskService.CreateTaskAsync(task);

                return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var response = await _taskService.GetAllTasksAsync();

                return Ok(response); // 200 OK with resource data
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("tasks/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("record should be available for update");
            }

            try
            {
                var response = await _taskService.GetTaskByIdAsync(id);

                return Ok(response); // 200 OK with resource data
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPut("tasks")]
        public async Task<IActionResult> Updatetask(TodoTask task)
        {
            try
            {
                if(task.TaskID <=0)
                {
                    return BadRequest("record should be available for update");
                }
                var response = await _taskService.UpdateTaskAsync(task);

                return Ok(response); // 200 OK with resource data
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }
        
        [HttpPut("tasks/complete/{id}")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            try
            {
                var response = await _taskService.MarkAsCompleted(id);

                return Ok(response); // 200 OK with resource data
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            try
            {
                var response = await _taskService.DeleteTaskByIdAsync(id);

                return Ok(response); // 200 OK with resource data
            }
            catch(InvalidRequestException ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }
    }
}
