using Microsoft.EntityFrameworkCore;
using StudentList.DataBase.Entity;

namespace StudentList.DataBase.Context
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> StudentList { get; set; }
    }
}
