using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Repository
{
    public interface ITaskRepository
    {
        Task<int> CreateNewTask(int id, TaskModel taskModel);
        Task<List<ProjectViewModel>> GetAllTaskByProjectId(int Id);
    }
}
