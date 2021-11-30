using CYYVG6_HFT_2021221.Models;
using System;

namespace CYYVG6_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:5000");


            rest.Post<Faculty>(new Faculty()
            {
                FacultyName = "Dob Faculty for Art",
                FacultyAddress = "1034 Budapest, Dob u. 9"

            }, "faculty");

            var faculties = rest.Get<Faculty>("faculty");
            var students = rest.Get<Student>("student");
            var employees = rest.Get<Employee>("employees");



            int highestsalary = rest.GetSingle<int>("stat/highestsalary");
            int salaryuniversitypayforallemp = rest.GetSingle<int>("stat/salaryuniversitypayforallemp");
            double avgageofstudents = rest.GetSingle<double>("stat/avgageofstudents");
            int numofstudeniIuUniversity = rest.GetSingle<int>("stat/numofstudeniIuUniversity");
            int moneyuniversityearnfromstudent = rest.GetSingle<int>("stat/moneyuniversityearnfromstudent");



        }
    }
}
