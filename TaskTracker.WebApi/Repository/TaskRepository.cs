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
    public class TaskRepository:ITaskRepository
    {
        private readonly TaskTrackerDbContext _context = null;
        public TaskRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateNewTask(int id, TaskModel taskModel)
        {
            var task = new Taskk()
            {
                TaskName = taskModel.TaskName,
                Description = taskModel.Description,
                TaskkStatus = Enums.TaskkStatus.ToDo,
                Priority = taskModel.Priority,
                ProjecttId = id
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task<List<ProjectViewModel>> GetAllTaskByProjectId(int Id)
        {
            return  await _context.Projects.Where(p => p.Id == Id)
                .Select(projectModel => new ProjectViewModel
                {
                    Id = projectModel.Id,
                    ProjectName = projectModel.ProjectName,
                    StartDate = projectModel.StartDate,
                    CompletionDate = projectModel.CompletionDate,
                    ProjectStatus = projectModel.ProjectStatus,
                    Priority = projectModel.Priority,
                    EditDate = projectModel.EditDate,
                    TaskViewModels = projectModel.Taskks.Where(p => p.ProjecttId == Id)
                    .Select(task=>new TaskViewModel{ 
                        Id=task.Id,
                        TaskName=task.TaskName,
                        Description=task.Description,
                        Priority = task.Priority,
                        TaskkStatus=task.TaskkStatus,
                        EditDate=task.EditDate,
                        ProjectId=projectModel.Id
                    }).ToList()
                }).ToListAsync();
        }
    }
}
