
namespace TaskTracker.WebApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(TaskTrackerDbContext dbContext) {
            dbContext.Database.EnsureCreated();
        }
    }
}
