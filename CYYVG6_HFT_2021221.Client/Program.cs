using ConsoleTools;
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using StudentSystem.Data;
using System;
using System.Linq;

namespace CYYVG6_HFT_2021221.Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            MenuMethods menuMethods = new MenuMethods();

            var subMenuCreate = new ConsoleMenu(args, level: 1)
            .Add("==> ADD A NEW STUDENT", () => menuMethods.AddNewStudent())
            .Add("==> ADD A NEW EMPLOYEE", () => menuMethods.AddNewEmployee())
            .Add("==> ADD A NEW FACULTY", () => menuMethods.AddNewFaculty())
            .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "Submenu";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
            });

             var subMenuList = new ConsoleMenu(args, level: 1)
             .Add("==> LIST ALL STUDENTS", () => menuMethods.ListAllStudents())
             .Add("==> LIST ALL EMPLOYEES", () => menuMethods.ListAllEmployees())
             .Add("==> LIST ALL FACULTIES", () => menuMethods.ListAllFaculties())
             .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
             .Configure(config =>
             {
                 config.Selector = "--> ";
                 config.EnableFilter = true;
                 config.Title = "Submenu";
                 config.EnableBreadcrumb = true;
                 config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
             });

            var subMenuGetBy = new ConsoleMenu(args, level: 1)
               .Add("==> GET ONE STUDENT BY ID", () => menuMethods.GetOneStudent())
               .Add("==> GET ONE EMPLOYEE BY ID", () => menuMethods.GetOneEmployee())
               .Add("==> GET ONE FACULTY BY ID", () => menuMethods.GetOneFaculty())
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Submenu";
                   config.EnableBreadcrumb = true;
                   config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
               });

            var subMenuListRead = new ConsoleMenu(args, level: 1)
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

            var subMenuUpdate = new ConsoleMenu(args, level: 1)
               .Add("==> CHANGE STUDENT ID", () => menuMethods.ChangeStudentId())
               .Add("==> CHANGE EMPLOYEE EMAIL", () => menuMethods.ChangeEmployeeEmail())
               .Add("==> CHANGE FACULTY ADDRESS", () => menuMethods.ChangeFacultyAddress())
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Submenu";
                   config.EnableBreadcrumb = true;
                   config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
               });

            var subMenuDelete = new ConsoleMenu(args, level: 1)
                .Add("==> DELETE STUDENT", () => menuMethods.DeleteStudent())
                .Add("==> DELETE EMPLOYEE", () => menuMethods.DeleteEmployee())
                .Add("==> DELETE FACULTY", () => menuMethods.DeleteFaculty())
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
                });

            var subMenuNonCrud = new ConsoleMenu(args, level: 1)
                .Add("==> QUERY1 - THE FACULTY OF A STUDENT", () => menuMethods.FacultyOfStudent())
                .Add("==> QUERY2 - THE FACULTY THAT PAYS THE MOST", () => menuMethods.FacultyPaysHighestSalary())
                .Add("==> QUERY3 - THE SUPERVISOR OF A STUDENT", () => menuMethods.SupervisorOfAStudent())
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = t => Console.WriteLine(string.Join(" / ", t));
                });

            var subMenuUniversity = new ConsoleMenu()
            .Add("==>  CREATE", () => subMenuCreate.Show())
            .Add("==>  READ", () => subMenuListRead.Show())
            .Add("==>  UPDATE", () => subMenuUpdate.Show())
            .Add("==>  DELETE", () => subMenuDelete.Show())
            .Add("==>  NON-CRUD - QUERIES", () => subMenuNonCrud.Show())
            .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "University Menu";
                config.EnableWriteTitle = true;
                config.EnableBreadcrumb = true;
            });


            var menu = new ConsoleMenu()
              .Add("==> Continue", () => subMenuUniversity.Show())
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

    }
}
