using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
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
        IFacultyLogic fl;

        public StatController(IFacultyLogic fl)
        {
            this.fl = fl;
        }


        // GET: stat/facultyofstudent
        [HttpGet("{id}")]
        public Faculty FacultyOfStudent(int id)
        {
            return fl.FacultyOfStudent(id);
        }

        // GET: stat/facultypayshighestsalary
        [HttpGet]
        public Faculty FacultyPaysHighestSalary()
        {
            return fl.FacultyPaysHighestSalary();
        }

        // GET: stat/facultypayslowestsalary
        [HttpGet]
        public Faculty FacultyPaysLowestSalary()
        {
            return fl.FacultyPaysLowestSalary();
        }

        // GET: stat/supervisorofastudent
        [HttpGet("{id}")]
        public Employee SupervisorOfAStudent(int id)
        {
            return fl.SupervisorOfAStudent(id);
        }

        // GET: stat/facultyearnings
        [HttpGet]
        public IList<FacultyEarningsResult> FacultyEarnings()
        {
            return fl.FacultyEarnings();
        }




    }
}