using CYYVG6_HFT_2021221.Models;
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
        public virtual DbSet<Employee> Employee { get; set; }

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
                    .UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf; Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student s0 = new Student() { StudentId = 1, FulName = "John LC", Age = 23, Nationality = "Spanish", Major= "Electirical Engineering", SpeaksHungarian = false, PriceToPayPerSemester = 2800 };
            Student s1 = new Student() { StudentId = 2, FulName = "Manar Al-Absi", Age = 21, Nationality = "Yemeni", Major = "Computer Scince and Engineering", SpeaksHungarian = false, PriceToPayPerSemester = 3000 };
            Student s2 = new Student() { StudentId = 3, FulName = "Attila Tomas", Age = 28, Nationality = "Hungrian", Major = "Mechanical Engineering", SpeaksHungarian = true, PriceToPayPerSemester = 2800 };
            Student s3 = new Student() { StudentId = 4, FulName = "Moo Joo", Age = 24, Nationality = "Jordan", Major = "Environmental Engineering", SpeaksHungarian = true, PriceToPayPerSemester = 2500 };


            Faculty f0 = new Faculty() { FacultyId = 1, FacultyName = "John von Neumann Faculty of Informatics", FacultyAddress = "1034 Budapest, Becsi u. 96b", StudentId=s1.StudentId };
            Faculty f1 = new Faculty() { FacultyId = 2, FacultyName = "BÁNKI DONÁT FACULTY OF MECHANICAL AND SAFETY ENGINEERING", FacultyAddress = "1081 Budapest, Nepszinhaz u. 8", StudentId = s2.StudentId };
            Faculty f2 = new Faculty() { FacultyId = 3, FacultyName = "Rejtő Sándor Faculty of Light Industry and Environmental Engineering", FacultyAddress = "1034 Budapest, Doberdo ut 6", StudentId = s3.StudentId };
            Faculty f3 = new Faculty() { FacultyId = 4, FacultyName = "Kandó Kálmán Faculty of Electrical Engineering", FacultyAddress = "1034 Budapest, Becsi u. 94-96", StudentId = s0.StudentId };


            Employee e0 = new Employee() { EmployeeId = 1, FulName = "Klespitz Jozsef", Age = 38, Address = "1074 Budapest, Absd u. 9", FacultyId=f0.FacultyId, Email = "abcd@gmail.com", Position = "Professor", Salary = 3000 };
            Employee e1 = new Employee() { EmployeeId = 2, FulName = "Kristina Petrovikj", Age= 25, Address= "1066 Budapest, Efgh u. 6", FacultyId = f3.FacultyId, Email = "efgh@gmail.com", Position = "Lecturer", Salary = 1000 };
            Employee e2 = new Employee() { EmployeeId = 3, FulName = "Siklosi daniel", Age = 30, Address = "1081 Budapest, Ijkl u. 8", FacultyId = f1.FacultyId, Email = "ijkl@gmail.com", Position = "Programmer",Salary = 1800};
            Employee e3 = new Employee() { EmployeeId = 4, FulName = "Borbas Laszlo", Age = 51, Address = "1034 Budapest, Mnop ut 67", FacultyId = f2.FacultyId, Email = "mnop@gmail.com", Position = "Manager", Salary = 5000};





            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasOne(faculty => faculty.Student)
                    .WithMany(Student => Student.Faculties)
                    .HasForeignKey(faculty => faculty.StudentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(employee => employee.Faculty)
                    .WithMany(Faculty => Faculty.Employees)
                    .HasForeignKey(employee => employee.FacultyId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Student>().HasData(s0, s1, s2, s3);
            modelBuilder.Entity<Faculty>().HasData(f0, f1, f2, f3);
            modelBuilder.Entity<Employee>().HasData(e0, e1, e2, f3);
        }
    }
}