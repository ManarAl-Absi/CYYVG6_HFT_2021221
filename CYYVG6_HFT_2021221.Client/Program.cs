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
            StudentsOfObudaUniDbContext context = new StudentsOfObudaUniDbContext();
            EmployeeRepository employeeRepository = new EmployeeRepository(context);
            StudentRepository studentRepository = new StudentRepository(context);
            FacultyRepository facultyRepository = new FacultyRepository(context);
            EmployeeLogic employeeLogic = new EmployeeLogic(employeeRepository);
            StudentLogic studentLogic = new StudentLogic(studentRepository);
            FacultyLogic facultyLogic = new FacultyLogic(facultyRepository);

            var subMenuCreate = new ConsoleMenu()
                 .Add("==> ADD A NEW STUDENT", () => AddNewStudent(studentLogic))
                 .Add("==> ADD A NEW EMPLOYEE", () => AddNewEmployee(employeeLogic))
                 .Add("==> ADD A NEW FACULTY", () => AddNewFaculty(facultyLogic))
                 .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                 });
            
            var subMenuList = new ConsoleMenu()
                .Add("==> LIST ALL STUDENTS", () => ListAllStudents(studentLogic))
                .Add("==> LIST ALL EMPLOYEES", () => ListAllEmployees(employeeLogic))
                .Add("==> LIST ALL FACULTIES", () => ListAllFaculties(facultyLogic))
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                });

            var subMenuGetBy = new ConsoleMenu()
               .Add("==> GET ONE STUDENT BY ID", () => GetOneStudent(studentLogic))
               .Add("==> GET ONE EMPLOYEE BY ID", () => GetOneEmployee(employeeLogic))
               .Add("==> GET ONE FACULTY BY ID", () => GetOneFaculty(facultyLogic))
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.Blue;
               });

            var subMenuListRead = new ConsoleMenu()
               .Add("==> LIST ALL", () => subMenuList.Show())
               .Add("==> GET ONE BY ID", () => subMenuGetBy.Show())
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.Blue;
               });

            var subMenuUpdate = new ConsoleMenu()
               .Add("==> CHANGE STUDENT ID", () => ChangeStudentId(studentLogic))
               .Add("==> CHANGE EMPLOYEE EMAIL", () => ChangeEmployeeEmail(employeeLogic))
               .Add("==> CHANGE FACULTY ADDRESS", () => ChangeFacultyAddress(facultyLogic))
               .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.Blue;
               });

            var subMenuDelete = new ConsoleMenu()
                .Add("==> DELETE STUDENT", () => DeleteStudent(studentLogic))
                .Add("==> DELETE EMPLOYEE", () => DeleteEmployee(employeeLogic))
                .Add("==> DELETE FACULTY", () => DeleteFaculty(facultyLogic))
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                });

            var subMenuNonCrud = new ConsoleMenu()
                .Add("==> QUERY1 - THE NUMBER OF STUDENTS IN THE UNIVERSITY", () => NumberOfStudentInUniversity(studentLogic))
                .Add("==> QUERY2 - THE MONEY UNIVERSITY PAY TO EMPLOYEES", () => OutcomeOfUniToEmployee(employeeLogic))
                .Add("==> QUERY3 - THIS IS THE FACULTY THAT PAYS THE HIGHEST SALARY", () => GetTheFacultyThatPaysTheHighestSalary(facultyLogic))
                .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Blue;
                });

            var subMenuUniversity = new ConsoleMenu()
            .Add("==> C - CREATE", () => subMenuCreate.Show())
            .Add("==> R - READ", () => subMenuListRead.Show())
            .Add("==> U - UPDATE", () => subMenuUpdate.Show())
            .Add("==> D - DELETE", () => subMenuDelete.Show())
            .Add("==> NON-CRUD - QUERIES", () => subMenuNonCrud.Show())
            .Add("==> GO BACK TO MENU", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.SelectedItemBackgroundColor = ConsoleColor.Blue;
            });


            var menu = new ConsoleMenu()
              .Add("==> ENTER AS A VISITOR ", () => subMenuUniversity.Show())
              .Add("==> EXIT", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.SelectedItemBackgroundColor = ConsoleColor.Blue;
              });

            menu.Show();


        }
        // Create Methods
        private static void AddNewStudent(StudentLogic studentLogic)
        {
            try
            {
                Console.WriteLine("\n---- CREATING A NEW STUDENT ----\n");
                Console.WriteLine("Type the student ID: ");
                int studentId = int.Parse(Console.ReadLine());
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
                Student stud = new Student() {
                    StudentId = studentId,
                    FulName = studentName,
                    Major = studentMajor,
                    Gender = studentGender,
                    Age = studentAge,
                    Nationality = studentNationality,
                    SpeaksHungarian = doesSpeakHungarian,
                    TitutionPrice = titutionFee
                }; 
                studentLogic.Create(stud);

                Console.WriteLine($"\n ---- {stud.FulName} ADDED SUCCESSFULLY! ----\n");
                Console.WriteLine(stud.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void AddNewEmployee(EmployeeLogic employeeLogic)
        {
            try
            {
                Console.WriteLine("\n---- CREATING A NEW EMPLOYEE ----\n");
                Console.WriteLine("Type the employee ID: ");
                int employeeId = int.Parse(Console.ReadLine());

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


                Employee emp = new Employee()
                {
                    EmployeeId = employeeId,
                    FulName = employeeName,
                    Address = employeeAddress,
                    Email = employeeEmail,
                    Age = employeeAge,
                    Position = employeePosition,
                    Salary = employeeSalary,
                };
                employeeLogic.Create(emp);

                Console.WriteLine($"\n ---- {emp.FulName} ADDED SUCCESSFULLY! ----\n");
                Console.WriteLine(emp.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void AddNewFaculty(FacultyLogic facultyLogic)
        {
            try
            {
                Console.WriteLine("\n---- CREATING A NEW FACULTY ----\n");

                Console.WriteLine("Type the faculty ID: ");
                int facultyId = int.Parse(Console.ReadLine());

                Console.WriteLine("Type the faculty name: ");
                string facultyName = Console.ReadLine();

                Console.WriteLine("Type the faculty address: ");
                string facultyAddress = Console.ReadLine();
                
                Faculty fac = new Faculty()
                {
                    FacultyId = facultyId,
                    FacultyName = facultyName,
                    FacultyAddress = facultyAddress
                };
                facultyLogic.Create(fac);

                Console.WriteLine($"\n ---- {fac.FacultyName} ADDED SUCCESSFULLY! ----\n");
                Console.WriteLine(fac.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        
        // List All Methods
        private static void ListAllStudents(StudentLogic studentLogic)
        {
            Console.WriteLine("\n---- ALL Students ----\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ResetColor();
            studentLogic.GetAll().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void ListAllEmployees(EmployeeLogic employeeLogic)
        {
            Console.WriteLine("\n---- ALL Employees ----\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ResetColor();
            employeeLogic.GetAll().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void ListAllFaculties(FacultyLogic facultyLogic)
        {
            Console.WriteLine("\n---- ALL Faculties ----\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ResetColor();
            facultyLogic.GetAll().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        
        // Read Methods
        private static void GetOneStudent(StudentLogic studentLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.ResetColor();
                Console.WriteLine(studentLogic.Read(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void GetOneEmployee(EmployeeLogic employeeLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.ResetColor();
                Console.WriteLine(employeeLogic.Read(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void GetOneFaculty(FacultyLogic facultyLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.ResetColor();
                Console.WriteLine(facultyLogic.Read(id).ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Delete methods
        private static void DeleteStudent(StudentLogic studentLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                studentLogic.Delete(id);
                Console.WriteLine($"\n -----{studentLogic.Read(id).StudentId} RECORD SUCCESSFULLY DELETED ----\n");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void DeleteEmployee(EmployeeLogic employeeLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                employeeLogic.Delete(id);
                Console.WriteLine($"\n -----{employeeLogic.Read(id).EmployeeId} RECORD SUCCESSFULLY DELETED ----\n");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void DeleteFaculty(FacultyLogic facultyLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                facultyLogic.Delete(id);
                Console.WriteLine($"\n -----{facultyLogic.Read(id).FacultyId} RECORD SUCCESSFULLY DELETED ----\n");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Update Methods
        private static void ChangeStudentId(StudentLogic studentLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW ID! ----");
                int studentId = int.Parse(Console.ReadLine());
                studentLogic.Read(id).StudentId = studentId;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                studentLogic.Update(studentLogic.Read(id));
                Console.WriteLine($"\n -----{studentLogic.Read(id).StudentId} WAS SUCCESSFULLY UPDATED ----\n");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void ChangeEmployeeEmail(EmployeeLogic employeeLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW EMAIL! ----");
                string employeeEmail = Console.ReadLine();
                employeeLogic.Read(id).Email = employeeEmail;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                employeeLogic.Update(employeeLogic.Read(id));
                Console.WriteLine($"\n -----{employeeLogic.Read(id).Email} WAS SUCCESSFULLY UPDATED ----\n");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void ChangeFacultyAddress(FacultyLogic facultyLogic)
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW ADDRESS! ----");
                string facultyAddress = Console.ReadLine();
                facultyLogic.Read(id).FacultyAddress = facultyAddress;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                facultyLogic.Update(facultyLogic.Read(id));
                Console.WriteLine($"\n -----{facultyLogic.Read(id).FacultyAddress} WAS SUCCESSFULLY UPDATED ----\n");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Non-Crud Method
        private static void NumberOfStudentInUniversity(StudentLogic studentLogic)
        {
            Console.WriteLine("---> THIS IS THE NUMBER OF STUDENTS IN THE UNIVERSITY!");
            int item = studentLogic.NumOfStudentInUniversity();

            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        private static void OutcomeOfUniToEmployee(EmployeeLogic employeeLogic)
        {
            Console.WriteLine("\n---> THIS IS THE MONEY FOR THE WHOLE UNIVERSITY EMPLOYEES!\n");
            var item = employeeLogic.SalaryUniversityPayForAllEmp();
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
        private static void GetTheFacultyThatPaysTheHighestSalary(FacultyLogic facultyLogic)
        {
            Console.WriteLine("---> THIS IS THE FACULTY THAT PAYS THE HIGHEST SALARY!");

            var item = facultyLogic.FacultyPaysHighestSalary();
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

    }
}
