
namespace TaskTracker.WebApi.Data
{
    //for initializing database if doesn't have database in sql server this command will create database
    public class DbInitializer
    {
        public static void Initialize(TaskTrackerDbContext dbContext) {
            dbContext.Database.EnsureCreated();
        }
    }
}
