using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.WebApi.Data;
using TaskTracker.WebApi.Entity;
using TaskTracker.WebApi.Models;
using TaskTracker.WebApi.Repository;
using TaskTracker.WebApi.Validator;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly TaskTrackerDbContext _context;
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(TaskTrackerDbContext context, IProjectRepository projectRepository)
        {
            _context = context;
            _projectRepository = projectRepository;
        }

        // GET: api/Projectts
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var data = await _projectRepository.GetAllProject();
            return Ok(data);
        }

        // GET: api/Projectts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var projectt = await _projectRepository.GetProjectById(id);

            if (projectt == null)
            {
                return NotFound();
            }

            return Ok(projectt);
        }

        // PUT: api/Projectts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectt(int id, Projectt projectt)
        {
            if (id != projectt.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjecttExists(id))
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

        // POST: api/CreateProject
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectModel projectModel)
        {
            ProjectValidator validationRules = new();
            var validatorResult = validationRules.Validate(projectModel);
            if (validatorResult.IsValid)
            {
                int id = await _projectRepository.CreateNewProject(projectModel);
                if (id > 0)
                {
                    var projectWithIdModel = await _projectRepository.GetProjectById(id);
                    return Ok(projectWithIdModel);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
        }

        //DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectt(int id)
        {
            var projectt = await _context.Projects.FindAsync(id);
            if (projectt == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjecttExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
