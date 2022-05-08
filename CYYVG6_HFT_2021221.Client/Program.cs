using ConsoleTools;
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CYYVG6_HFT_2021221.Client
{
    internal class Program
    {
        static RestService rest;
        public static void Main(string[] args)
        {
            rest = new RestService("http://localhost:47153", "university");

            //StudentsOfObudaUniDbContext context = new StudentsOfObudaUniDbContext();
            //EmployeeRepository employeeRepository = new EmployeeRepository(context);
            //StudentRepository studentRepository = new StudentRepository(context);
            //FacultyRepository facultyRepository = new FacultyRepository(context);
            //EmployeeLogic employeeLogic = new EmployeeLogic(employeeRepository);
            //StudentLogic studentLogic = new StudentLogic(studentRepository);
            //FacultyLogic facultyLogic = new FacultyLogic(facultyRepository);

            var subMenuCreate = new ConsoleMenu(args, level: 2)
                 .Add("==> ADD A NEW STUDENT", () => Create("Student"))
                 .Add("==> ADD A NEW EMPLOYEE", () => Create("Employee"))
                 .Add("==> ADD A NEW FACULTY", () => Create("Faculty"))
                 .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                 });

            var subMenuList = new ConsoleMenu(args, level: 2)
                .Add("==> LIST ALL STUDENTS", () => ListAll("Student"))
                .Add("==> LIST ALL EMPLOYEES", () => ListAll("Employee"))
                .Add("==> LIST ALL FACULTIES", () => ListAll("Faculty"))
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                });

            var subMenuGetBy = new ConsoleMenu(args, level: 2)
               .Add("==> GET ONE STUDENT BY ID", () => GetOne("Student"))
               .Add("==> GET ONE EMPLOYEE BY ID", () => GetOne("Employee"))
               .Add("==> GET ONE FACULTY BY ID", () => GetOne("Faculty"))
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Submenu";
                   config.EnableBreadcrumb = true;
                   config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
               });

            var subMenuListRead = new ConsoleMenu(args, level: 2)
               .Add("==> LIST ALL", () => subMenuList.Show())
               .Add("==> GET ONE BY ID", () => subMenuGetBy.Show())
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Submenu";
                   config.EnableBreadcrumb = true;
                   config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
               });

            var subMenuUpdate = new ConsoleMenu(args, level: 2)
               .Add("==> CHANGE STUDENT MAJOR", () => Update("Student"))
               .Add("==> CHANGE EMPLOYEE EMAIL", () => Update("Employee"))
               .Add("==> CHANGE FACULTY ADDRESS", () => Update("Faculty"))
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Submenu";
                   config.EnableBreadcrumb = true;
                   config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
               });

            var subMenuDelete = new ConsoleMenu(args, level: 2)
                .Add("==> DELETE STUDENT", () => Delete("Student"))
                .Add("==> DELETE EMPLOYEE", () => Delete("Employee"))
                .Add("==> DELETE FACULTY", () => Delete("Faculty"))
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
                });

            //var subMenuNonCrud = new ConsoleMenu(args, level: 2)
            //    .Add("==> QUERY1 - THE NUMBER OF STUDENTS IN THE UNIVERSITY", () => NumberOfStudentInUniversity(studentLogic))
            //    .Add("==> QUERY2 - THE MONEY UNIVERSITY PAY TO EMPLOYEES", () => OutcomeOfUniToEmployee(employeeLogic))
            //    .Add("==> QUERY3 - THIS IS THE FACULTY THAT PAYS THE HIGHEST SALARY", () => GetTheFacultyThatPaysTheHighestSalary(facultyLogic))
            //    .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
            //    .Configure(config =>
            //    {
            //        config.Selector = "--> ";
            //        config.SelectedItemBackgroundColor = ConsoleColor.Blue;
            //    });

            var subMenuUniversity = new ConsoleMenu(args, level: 1)
            .Add("==> C - CREATE", () => subMenuCreate.Show())
            .Add("==> R - READ", () => subMenuListRead.Show())
            .Add("==> U - UPDATE", () => subMenuUpdate.Show())
            .Add("==> D - DELETE", () => subMenuDelete.Show())
            //.Add("==> NON-CRUD - QUERIES", () => subMenuNonCrud.Show())
            .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "University Menu";
                config.EnableWriteTitle = true;
                config.EnableBreadcrumb = true;
            });


            var menu = new ConsoleMenu(args, level: 0)
              .Add("==> ENTER AS A VISITOR ", () => subMenuUniversity.Show())
              .Add("==> EXIT", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = true;
                  config.Title = "Main Menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();


        }
        // Create Method
        static void Create(string entity)
        {
            if (entity == "Student")
            {
                Console.WriteLine("\n---- CREATING A NEW STUDENT ----\n");
                Console.WriteLine("Type the student name: ");
                string studentName = Console.ReadLine();
                Console.WriteLine("Type the student major: ");
                string studentMajor = Console.ReadLine();
                Console.WriteLine("Type the student gender: ");
                string studentGender = Console.ReadLine();
                Console.WriteLine("Type the student age: ");
                int studentAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Type the student nationality: ");
                string studentNationality = Console.ReadLine();
                Console.WriteLine("Does he/she speak Hungarian (true/false): ");
                bool doesSpeakHungarian = bool.Parse(Console.ReadLine());
                Console.WriteLine("Type the titution fee: ");
                int titutionFee = int.Parse(Console.ReadLine());
                rest.Post(new Student()
                {
                    FulName = studentName,
                    Major = studentMajor,
                    Gender = studentGender,
                    Age = studentAge,
                    Nationality = studentNationality,
                    SpeaksHungarian = doesSpeakHungarian,
                    TitutionPrice = titutionFee
                }, "student");

                Console.WriteLine($"\n ---- ADDED SUCCESSFULLY! ----\n");
                Console.ReadLine();
            }
            else if (entity == "Employee")
            {
                Console.WriteLine("\n---- CREATING A NEW EMPLOYEE ----\n");
                Console.WriteLine("Type the employee name: ");
                string employeeName = Console.ReadLine();

                Console.WriteLine("Type the employee address: ");
                string employeeAddress = Console.ReadLine();

                Console.WriteLine("Type the employee emial: ");
                string employeeEmail = Console.ReadLine();

                Console.WriteLine("Type the employee age: ");
                int employeeAge = int.Parse(Console.ReadLine());

                Console.WriteLine("Type the employee position: ");
                string employeePosition = Console.ReadLine();

                Console.WriteLine("Type the employee salary:  ");
                int employeeSalary = int.Parse(Console.ReadLine());


                rest.Post(new Employee()
                {
                    FulName = employeeName,
                    Address = employeeAddress,
                    Email = employeeEmail,
                    Age = employeeAge,
                    Position = employeePosition,
                    Salary = employeeSalary,
                }, "employee");
                Console.WriteLine($"\n ---- ADDED SUCCESSFULLY! ----\n");
                Console.ReadLine();
            }
            else if (entity == "Faculty")
            {
                Console.WriteLine("\n---- CREATING A NEW FACULTY ----\n");

                Console.WriteLine("Type the faculty name: ");
                string facultyName = Console.ReadLine();

                Console.WriteLine("Type the faculty address: ");
                string facultyAddress = Console.ReadLine();

                rest.Post(new Faculty()
                {
                    FacultyName = facultyName,
                    FacultyAddress = facultyAddress
                }, "faculty");

                Console.WriteLine($"\n ---- ADDED SUCCESSFULLY! ----\n");
                Console.ReadLine();
            }
        }


        // List All Methods
        static void ListAll(string entity)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ResetColor();
            if (entity == "Student")
            {
                Console.WriteLine("\n---- ALL Students ----\n");
                List<Student> students = rest.Get<Student>("student");
                foreach (var item in students)
                {
                    Console.WriteLine(item.StudentId + ": " + item.FulName);
                }
            }
            else if (entity == "Employee")
            {
                Console.WriteLine("\n---- ALL Employees ----\n");
                List<Employee> employees = rest.Get<Employee>("employee");
                foreach (var item in employees)
                {
                    Console.WriteLine(item.EmployeeId + ": " + item.FulName);
                }
            }
            else if (entity == "Faculty")
            {
                Console.WriteLine("\n---- ALL Faculties ----\n");
                List<Faculty> faculties = rest.Get<Faculty>("faculty");
                foreach (var item in faculties)
                {
                    Console.WriteLine(item.FacultyId + ": " + item.FacultyName);
                }
            }
            Console.ReadLine();
        }


        // Read Methods
        private static void GetOne(string entity)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DISPLAY ----\n");
            if (entity == "Student")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DISPLAY ----\n");
                int id = int.Parse(Console.ReadLine());
                Student student = rest.Get<Student>(id, "student");
                Console.WriteLine(student.StudentId + ": " + student.FulName);
            }
            else if (entity == "Employee")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DISPLAY ----\n");
                int id = int.Parse(Console.ReadLine());
                Employee employee = rest.Get<Employee>(id, "employee");
                Console.WriteLine(employee.EmployeeId + ": " + employee.FulName);
            }
            else if (entity == "Faculty")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY YOU WANT TO DISPLAY ----\n");
                int id = int.Parse(Console.ReadLine());
                Faculty faculty = rest.Get<Faculty>(id, "faculty");
                Console.WriteLine(faculty.FacultyId + ": " + faculty.FacultyName);
            }
        }

        // Delete methods
        static void Delete(string entity)
        {
            if (entity == "Student")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DELETE ----\n");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "student");
            }
            else if (entity == "Employee")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DELETE ----\n");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "employee");
            }
            else if (entity == "Faculty")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY YOU WANT TO DELETE ----\n");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "faculty");
            }
        }

        // Update Methods 
        static void Update(string entity)
        {

            if (entity == "Student")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT TO UPDATE ----\n");
                int id = int.Parse(Console.ReadLine());
                Student old = rest.Get<Student>(id, "student");
                Console.WriteLine("\n ---- TYPE THE NEW MAJOR! ----");
                string newMajor = Console.ReadLine();
                Console.WriteLine("\n ---- UPDATING... ----\n");
                old.Major = newMajor;
                rest.Put(old, "student");
                Console.WriteLine($"\n ----- SUCCESSFULLY UPDATED ----\n");
                Console.ReadLine();
            }
            else if (entity == "Employee")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE TO UPDATE ----\n");
                int id = int.Parse(Console.ReadLine());
                Employee old = rest.Get<Employee>(id, "employee");
                Console.WriteLine("\n ---- TYPE THE NEW EMAIL! ----");
                string newEmail = Console.ReadLine();
                Console.WriteLine("\n ---- UPDATING... ----\n");
                old.Email = newEmail;
                rest.Put(old, "employee");
                Console.WriteLine($"\n ----- SUCCESSFULLY UPDATED ----\n");
                Console.ReadLine();
            }
            else if (entity == "Faculty")
            {
                Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY TO UPDATE ----\n");
                int id = int.Parse(Console.ReadLine());
                Faculty old = rest.Get<Faculty>(id, "faculty");
                Console.WriteLine("\n ---- TYPE THE NEW ADDRESS! ----");
                string newAddress = Console.ReadLine();
                Console.WriteLine("\n ---- UPDATING... ----\n");
                old.FacultyAddress = newAddress;
                rest.Put(old, "faculty");
                Console.WriteLine($"\n ----- SUCCESSFULLY UPDATED ----\n");
                Console.ReadLine();
            }
        }



        // Non-Crud Method
        //private static void NumberOfStudentInUniversity(StudentLogic studentLogic)
        //{
        //    Console.WriteLine("---> THIS IS THE NUMBER OF STUDENTS IN THE UNIVERSITY!");
        //    int item = studentLogic.NumOfStudentInUniversity();

        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}
        //private static void OutcomeOfUniToEmployee(EmployeeLogic employeeLogic)
        //{
        //    Console.WriteLine("\n---> THIS IS THE MONEY FOR THE WHOLE UNIVERSITY EMPLOYEES!\n");
        //    var item = employeeLogic.SalaryUniversityPayForAllEmp();
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();

        //}
        //private static void GetTheFacultyThatPaysTheHighestSalary(FacultyLogic facultyLogic)
        //{
        //    Console.WriteLine("---> THIS IS THE FACULTY THAT PAYS THE HIGHEST SALARY!");

        //    var item = facultyLogic.FacultyPaysHighestSalary();
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

    }
}
