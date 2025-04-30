using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain.Models;

namespace StudentAPI.Domain
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student>  Students { get; set; }

        public DbSet<Cource> Cources { get; set; }
    }
}
