using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using CYYVG6_HFT_2021221.Repository;
using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Client
{
    class MenuMethods
    {
        RestService restService = new RestService(@"http://localhost:47153");
   

        // Create Methods
        public void AddNewStudent()
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

            restService.Post<Student>(new Student()
            {
                StudentId = studentId,
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
        public void AddNewEmployee()
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


            restService.Post<Employee>(new Employee()
            {
                EmployeeId = employeeId,
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
        public void AddNewFaculty()
        {
            Console.WriteLine("\n---- CREATING A NEW FACULTY ----\n");
            Console.WriteLine("Type the faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the faculty name: ");
            string facultyName = Console.ReadLine();
            Console.WriteLine("Type the faculty address: ");
            string facultyAddress = Console.ReadLine();

            restService.Post<Faculty>(new Faculty()
            {
                 FacultyId = facultyId,
                 FacultyName = facultyName,
                 FacultyAddress = facultyAddress
            }, "faculty");
               
            Console.WriteLine($"\n ---- ADDED SUCCESSFULLY! ----\n");
            Console.ReadLine();
        }

        // List All Methods
        public void ListAllStudents()
        {
            Console.WriteLine("\n---- ALL Students ----\n");
            List<Student> students = restService.Get<Student>("student");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.ReadLine();
        }
        public void ListAllEmployees()
        {
            Console.WriteLine("\n---- ALL Employees ----\n");
            List<Employee> employees = restService.Get<Employee>("employee");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
            Console.ReadLine();
        }
        public void ListAllFaculties()
        {
            Console.WriteLine("\n---- ALL Faculties ----\n");
            List<Faculty> faculties = restService.Get<Faculty>("faculty");
            foreach (var faculty in faculties)
            {
                Console.WriteLine(faculty.ToString());
            }
            Console.ReadLine();
        }

        // Read Methods
        public void GetOneStudent()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Student student = restService.Get<Student>(id, "student");
                Console.WriteLine(student.ToString());
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
        public void GetOneEmployee()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Employee employee = restService.Get<Employee>(id, "employee");
                Console.WriteLine(employee.ToString());
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
        public void GetOneFaculty()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY YOU WANT TO DISPLAY ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Faculty faculty = restService.Get<Faculty>(id, "faculty");
                Console.WriteLine(faculty.ToString());
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
        public void DeleteStudent()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "faculty");
                Console.WriteLine($"\n ----- STUDENT RECORD OF ID {id} SUCCESSFULLY DELETED ----\n");
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
        public void DeleteEmployee()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "employee");
                Console.WriteLine($"\n ----- EMPLOYEE RECORD OF ID {id} SUCCESSFULLY DELETED ----\n");
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
        public void DeleteFaculty()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY YOU WANT TO DELETE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "faculty");
                Console.WriteLine($"\n ----- FACULTY RECORD OF ID {id} SUCCESSFULLY DELETED ----\n");
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
        public void ChangeStudentId()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE STUDENT TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW ID! ----");
                int studentId = int.Parse(Console.ReadLine());
                Student student = restService.Get<Student>(id, "student");
                student.StudentId = studentId;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                restService.Put<Student>(student, "student");
                Console.WriteLine($"\n -----STUDENT RECORD OF ID {id} WAS SUCCESSFULLY UPDATED ----\n");

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
        public void ChangeEmployeeEmail()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE EMPLOYEE TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW EMAIL! ----");
                string employeeEmail = Console.ReadLine();
                Employee employee = restService.Get<Employee>(id, "employee");
                employee.Email = employeeEmail;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                restService.Put<Employee>(employee, "employee");
                Console.WriteLine($"\n ----- EMPLOYEE RECORD OF ID {id} WAS SUCCESSFULLY UPDATED ----\n");

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
        public void ChangeFacultyAddress()
        {
            Console.WriteLine("\n---- TYPE THE ID OF THE FACULTY TO UPDATE ----\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n ---- TYPE THE NEW ADDRESS! ----");
                string facultyAddress = Console.ReadLine();
                Faculty faculty = restService.Get<Faculty>(id, "faculty");
                faculty.FacultyAddress = facultyAddress;
                Console.WriteLine("\n ---- UPDATING... ----\n");
                restService.Put<Faculty>(faculty, "faculty");
                Console.WriteLine($"\n ----- FACULTY RECORD OF ID {id} WAS SUCCESSFULLY UPDATED ----\n");

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
        public void FacultyOfStudent()
        {
            Console.WriteLine("---> THIS IS THE FACULTY OF A SPECIFIC STUDENT!");

            Faculty faculty = restService.GetSingle<Faculty>("stat/facultyofstudent");

            {
                Console.WriteLine(faculty.ToString());
            }

            Console.ReadLine();
        }
        public void FacultyPaysHighestSalary()
        {
            Faculty faculty = restService.GetSingle<Faculty>("stat/facultypayshighestsalary");
            {
                Console.WriteLine(faculty);
            }

            Console.ReadLine();

        }
        public void SupervisorOfAStudent()
        {
            Console.WriteLine("---> THIS IS THE SUPERVISOR OF A STUDENT!");

            Employee employee = restService.GetSingle<Employee>("stat/supervisorofastudent");
            {
                Console.WriteLine(employee);
            }

            Console.ReadLine();
        }
    }
}
