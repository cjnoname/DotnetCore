using DotnetCore.Model;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
