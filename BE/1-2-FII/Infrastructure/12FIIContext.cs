using _1_2_FII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class _12FIIContext : DbContext
    {
        public _12FIIContext(DbContextOptions<_12FIIContext> options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=ep-gentle-silence-a217xelp.eu-central-1.aws.neon.tech;Port=5432;Database=onetwofiiDB;Username=onetwofiiDB_owner;Password=YTdwpeP9itS6");
        //}
    }
}
