using CYYVG6_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDB.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStudentLogic sl;
        IEmployeeLogic el;

        public StatController(IStudentLogic sl, IEmployeeLogic el)
        {
            this.sl = sl;
            this.el = el;
        }


        // GET: stat/highestsalary
        [HttpGet]
        public int HighestSalary()
        {
            return el.HighestSalary();
        }

        // GET: stat/salaryuniversitypayforallemp
        [HttpGet]
        public int SalaryUniversityPayForAllEmp()
        {
            return el.SalaryUniversityPayForAllEmp();
        }

        // GET: stat/avgageofstudents
        [HttpGet]
        public double AVGAgeOfStudents()
        {
            return sl.AVGAgeOfStudents();
        }

        // GET: stat/numofstudeniIuUniversity
        [HttpGet]
        public int NumOfStudentInUniversity()
        {
            return sl.NumOfStudentInUniversity();
        }

        // GET: stat/moneyuniversityearnfromstudent
        [HttpGet]
        public int MoneyUniversityEarnFromStudent()
        {
            return sl.MoneyUniversityEarnFromStudent();
        }




    }
}