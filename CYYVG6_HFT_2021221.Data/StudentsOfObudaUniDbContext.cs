﻿using CYYVG6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public class StudentsOfObudaUniDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        public StudentsOfObudaUniDbContext()
        {
            this.Database.EnsureCreated();
        }

        public StudentsOfObudaUniDbContext(DbContextOptions<StudentsOfObudaUniDbContext> options)
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
            Student s0 = new Student() { StudentId = 1, FulName = "John LC", Age = 23, Nationality = "Spanish", Major= "Electirical Engineering", SpeaksHungarian = false, HasScholarship = true };
            Student s1 = new Student() { StudentId = 2, FulName = "Manar Al-Absi", Age = 21, Nationality = "Yemeni", Major = "Computer Scince and Engineering", SpeaksHungarian = false, HasScholarship = true };
            Student s2 = new Student() { StudentId = 3, FulName = "Attila Tomas", Age = 28, Nationality = "Hungrian", Major = "Mechanical Engineering", SpeaksHungarian = true, HasScholarship = false };
            Student s3 = new Student() { StudentId = 4, FulName = "Moo Joo", Age = 24, Nationality = "Jordan", Major = "Environmental Engineering", SpeaksHungarian = true, HasScholarship = true };


            Faculty f0 = new Faculty() { FacultyId = 1, FacultyName = "John von Neumann Faculty of Informatics", StudentId=s1.StudentId };
            Faculty f1 = new Faculty() { FacultyId = 2, FacultyName = "BÁNKI DONÁT FACULTY OF MECHANICAL AND SAFETY ENGINEERING", StudentId = s2.StudentId };
            Faculty f2 = new Faculty() { FacultyId = 3, FacultyName = "Rejtő Sándor Faculty of Light Industry and Environmental Engineering", StudentId = s3.StudentId };
            Faculty f3 = new Faculty() { FacultyId = 4, FacultyName = "Kandó Kálmán Faculty of Electrical Engineering", StudentId = s0.StudentId };


            Location l0 = new Location() { LocationId = 1, Address = "1034 Budapest, Becsi u. 96b", FacultyId=f0.FacultyId, IsNearDorm = true };
            Location l1 = new Location() { LocationId = 2, Address = "1034 Budapest, Becsi u. 94-96", FacultyId = f3.FacultyId, IsNearDorm = true };
            Location l2 = new Location() { LocationId = 3, Address = "1081 Budapest, Nepszinhaz u. 8", FacultyId = f1.FacultyId, IsNearDorm = false };
            Location l3 = new Location() { LocationId = 4, Address = "1034 Budapest, Doberdo ut 6", FacultyId = f2.FacultyId, IsNearDorm = true };





            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasOne(faculty => faculty.Student)
                    .WithMany(Student => Student.Faculties)
                    .HasForeignKey(faculty => faculty.StudentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(location => location.Faculty)
                    .WithMany(Faculty => Faculty.Locations)
                    .HasForeignKey(location => location.FacultyId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Student>().HasData(s0, s1, s2, s3);
            modelBuilder.Entity<Faculty>().HasData(f0, f1, f2);
        }
    }
}