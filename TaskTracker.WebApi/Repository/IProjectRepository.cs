using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Repository
{
    public interface IProjectRepository
    {
        Task<int> CreateNewProject(ProjectModel projectModel);
        Task<ProjectWithIdModel> GetProjectById(int id);
        Task<List<ProjectWithIdModel>> GetAllProject();
        //Task<ProjectWithIdModel> UpdateProject(int id, ProjectWithIdModel model);
    }
}
