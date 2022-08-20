using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.WebApi.Data;
using TaskTracker.WebApi.Entity;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Repository
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly TaskTrackerDbContext _context = null;
        public ProjectRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateNewProject(ProjectModel projectModel) {
            var newProject = new Projectt()
            {
                ProjectName = projectModel.ProjectName,
                StartDate = projectModel.StartDate,
                CompletionDate = projectModel.CompletionDate,
                ProjectStatus = Enums.ProjectStatus.NotStarted,
                Priority = projectModel.Priority
            };
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return newProject.Id;
        }

        public async Task<List<ProjectWithIdModel>> GetAllProject()
        {
            return await _context.Projects
                .Select(project => new ProjectWithIdModel
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    StartDate = project.StartDate,
                    CompletionDate = project.CompletionDate,
                    ProjectStatus = project.ProjectStatus,
                    Priority = project.Priority,
                    EditDate = project.EditDate
                }).ToListAsync();
        }

        public async Task<ProjectWithIdModel> GetProjectById(int id) {
            return await _context.Projects.Where(x => x.Id == id)
                .Select(projectWithId => new ProjectWithIdModel
                {
                    Id=projectWithId.Id,
                    ProjectName=projectWithId.ProjectName,
                    StartDate=projectWithId.StartDate,
                    CompletionDate=projectWithId.CompletionDate,
                    ProjectStatus=projectWithId.ProjectStatus,
                    Priority=projectWithId.Priority,
                    EditDate=projectWithId.EditDate
                }).FirstOrDefaultAsync();

        }

        
    }
}
