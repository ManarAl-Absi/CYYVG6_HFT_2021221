
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentLogic sl;
        public StudentController(IStudentLogic sl)
        {
            this.sl = sl;
        }

        //Get All
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return sl.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return sl.Read(id);
        }

        // Post
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            sl.Create(student);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Student student)
        {
            sl.Update(student);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }
    }
}