using Microsoft.EntityFrameworkCore;
using TaskTracker.WebApi.Entity;

namespace TaskTracker.WebApi.Data
{
    public class TaskTrackerDbContext:DbContext
    {
        public DbSet<Projectt> Projects { get; set; }
        //public DbSet<Taskk> Tasks { get; set; }
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> contextOptions)
            :base(contextOptions){}
    }
}
