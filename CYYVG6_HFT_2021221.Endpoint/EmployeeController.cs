
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic el;
        public EmployeeController(IEmployeeLogic el)
        {
            this.el = el;
        }

        //Get All
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return el.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return el.Read(id);
        }

        // Post
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            el.Create(employee);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            el.Update(employee);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            el.Delete(id);
        }
    }
}