using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.WebApi.Data;
using TaskTracker.WebApi.Entity;
using TaskTracker.WebApi.Models;
using TaskTracker.WebApi.Repository;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskTrackerDbContext _context;
        private readonly ITaskRepository _taskRepository;
        public TasksController(TaskTrackerDbContext context,
            ITaskRepository taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }
        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTaskByProjectWithId(int id)
        {
            var projectWithTasks = await _taskRepository.GetAllTaskByProjectId(id);

            if (projectWithTasks == null)
            {
                return NotFound();
            }

            return Ok(projectWithTasks);
        }
        //PUT: api/CreateTask

        [HttpPut("{Id}")]
        public async Task<IActionResult> CreateTask(int Id, [FromBody] TaskModel taskModel)
        {
            var project = _context.Projects.Find(Id);
            if (project != null)
            {
                var newTask = await _taskRepository.CreateNewTask(project.Id, taskModel);
                var projectWithTasks = await _taskRepository.GetAllTaskByProjectId(project.Id);
                return Ok(projectWithTasks);
            }

            return NotFound();
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateTask(int id, TaskModel taskModel)
        {
            var taskk = _context.Tasks.Where(t => t.Id == id);
            if (taskk == null)
            {
                return NotFound();
            }
            var task = new Taskk()
            {
                TaskName = taskModel.TaskName,
                Description = taskModel.Description,
                TaskkStatus = taskModel.TaskkStatus,
                Priority = taskModel.Priority,
                EditDate = System.DateTime.Now
            };
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}

