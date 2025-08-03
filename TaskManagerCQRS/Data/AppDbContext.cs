using Microsoft.EntityFrameworkCore;
using TaskManagerCQRS.Domain.Entities;

namespace TaskManagerCQRS.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
