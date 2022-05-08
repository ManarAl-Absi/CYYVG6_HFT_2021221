
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic el;
        IHubContext<SignalRHub> hub;

        public EmployeeController(IEmployeeLogic el, IHubContext<SignalRHub> hub)
        {
            this.el = el;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("EmployeeCreated", employee);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            this.el.Update(employee);
            this.hub.Clients.All.SendAsync("EmployeeUpdated", employee);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var empToDelete = this.el.Read(id);
            this.el.Delete(id);
            this.hub.Clients.All.SendAsync("EmployeeDeleted", empToDelete);
        }
    }
}