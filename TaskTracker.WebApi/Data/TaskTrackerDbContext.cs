using Microsoft.EntityFrameworkCore;
using TaskTracker.WebApi.Entity;

namespace TaskTracker.WebApi.Data
{
    public class TaskTrackerDbContext:DbContext
    {
        public DbSet<Projectt> Projects { get; set; }
        public DbSet<Taskk> Tasks { get; set; }
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> contextOptions)
            :base(contextOptions){}

        protected override void OnModelCreating(ModelBuilder modelbuilder) {
            modelbuilder.Entity<Taskk>()
                .HasOne(pt => pt.Projectt)
                .WithMany(ts=>ts.Taskks)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
