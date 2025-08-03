using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerCQRS.Features.Tasks.Commands.CreateTask;
using TaskManagerCQRS.Features.Tasks.Queries.GetAllTasks;

namespace TaskManagerCQRS.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var query = new GetAllTasksQuery();
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Invalid task data.");
            }

            var command = new CreateTaskCommand(title);
            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllTasks), new { id = taskId }, null);
        }
    }
}
