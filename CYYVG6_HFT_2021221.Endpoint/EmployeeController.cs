
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
            return this.el.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return this.el.Read(id);
        }

        // Post
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            this.el.Create(employee);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            this.el.Update(employee);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.el.Delete(id);
        }
    }
}