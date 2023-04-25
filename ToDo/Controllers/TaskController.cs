using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;
using ToDo.Models.Dtos;
using ToDo.Services.Interface;

namespace ToDo.Controllers
{
    [Route("api/task-management")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost("task")]
        public IActionResult CreateTask([FromBody] CreateTaskDto dto)
        {
            int taskId = _service.CreateTask(dto);
            return Ok(taskId);
        }

        [HttpPatch("task/{id}")]
        public IActionResult ChangeTask([FromBody] TaskProgress progress, [FromRoute] int id)
        {
            int state = _service.ChangeTaskState(progress, id);
            return Ok(state);
        }

        [HttpGet("task")]
        public IActionResult GetTasks()
        {
            var tasks = _service.GetTasks();
            return Ok(tasks);
        }

        [HttpDelete("task/{id}")]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            _service.DeleteTask(id);
            return NoContent();
        }
    }
}