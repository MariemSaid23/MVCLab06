using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace TrainningSystem.Models
{
    public class ITIContext :DbContext
    {
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UEK7P6N\\SQLEXPRESS;Database=system;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "SD", MangerName = "Alaa" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "OS", MangerName = "Asmaa" });
            modelBuilder.Entity<Instructor>()
                .HasData(new Instructor() { Id = 1, Name = "Ahmed", salary = 9000000, Imag = "m.jpg", address = "cairo", DepartmentId = 1 });
            modelBuilder.Entity<Instructor>()
                .HasData(new Instructor() { Id = 2, Name = "Muhammed", salary = 2000, Imag = "m2.jpg", address = "Menofia", DepartmentId = 2 });
            base.OnModelCreating(modelBuilder);
        }

    }
}
