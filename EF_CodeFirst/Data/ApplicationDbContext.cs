using EF_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId);

        // Seed podaci
        modelBuilder.Entity<Student>().HasData(
            new Student { StudentID = 1, StudentName = "Ivan Ivić", DateOfBirth = new DateTime(2000, 1, 1), Height = 180, Weight = 75 },
            new Student { StudentID = 2, StudentName = "Ana Anić", DateOfBirth = new DateTime(2001, 5, 15), Height = 165, Weight = 55 }
        );

        modelBuilder.Entity<Grade>().HasData(
            new Grade { GradeId = 1, GradeName = "Nedovoljan", Section = "", StudentId = 1 },
            new Grade { GradeId = 2, GradeName = "Dobar", Section = "", StudentId = 2 },
            new Grade { GradeId = 3, GradeName = "Dovoljan", Section = "", StudentId = 1 },
            new Grade { GradeId = 4, GradeName = "Odlican", Section = "", StudentId = 1 },
            new Grade { GradeId = 5, GradeName = "Odlican", Section = "", StudentId = 2 },
            new Grade { GradeId = 6, GradeName = "Vrlo dobar", Section = "", StudentId = 2 },
            new Grade { GradeId = 7, GradeName = "Dobar", Section = "", StudentId = 2 }
        );
    }
}
