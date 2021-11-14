using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public class StudentContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        public StudentContext()
        {
            this.Database.EnsureCreated();
        }

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null &&!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student s0 = new Student() { StudentId = 1, FulName = "John LC", Age = 23, Nationality = "Spanish", SpeaksHungarian = false, HasScholarship = true };
            Student s1 = new Student() { StudentId = 2, FulName = "Manar Al-Absi", Age = 21, Nationality = "Yemeni", SpeaksHungarian = false, HasScholarship = true };
            Student s2 = new Student() { StudentId = 3, FulName = "Attila Tomas", Age = 28, Nationality = "Hungrian", SpeaksHungarian = true, HasScholarship = false };
            Student s3 = new Student() { StudentId = 4, FulName = "Abood Sharaf", Age = 24, Nationality = "Jordan", SpeaksHungarian = true, HasScholarship = true };


            Faculty f0 = new Faculty() { FacultyId = 1, FacultyName = "John von Neumann Faculty of Informatics" };
            Faculty f1 = new Faculty() { FacultyId = 2, FacultyName = "BÁNKI DONÁT FACULTY OF MECHANICAL ANDSAFETY ENGINEERING" };
            Faculty f2 = new Faculty() { FacultyId = 3, FacultyName = "Rejtő Sándor Faculty of Light Industry and Environmental Engineering" };


            f0.StudentId = s0.StudentId;
            f1.StudentId = s1.StudentId;
            f2.StudentId = s2.StudentId;
            f1.StudentId = s3.StudentId;




            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasOne(Faculties => Faculties.Student)
                    .WithMany(Student => Student.Faculties)
                    .HasForeignKey(Faculties => Faculties.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Student>().HasData(s0, s1, s2, s3);
            modelBuilder.Entity<Faculty>().HasData(f0, f1, f2);
        }
    }
}