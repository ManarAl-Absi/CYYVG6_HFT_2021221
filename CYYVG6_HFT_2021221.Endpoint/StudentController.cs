
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentLogic sl;
        IHubContext<SignalRHub> hub;
        public StudentController(IStudentLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
        }

        //Get All
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return this.sl.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return this.sl.Read(id);
        }

        // Post
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            this.sl.Create(student);
            this.hub.Clients.All.SendAsync("StudentCreated", student);

        }

        // Put
        [HttpPut]
        public void Put([FromBody] Student student)
        {
            this.sl.Update(student);
            this.hub.Clients.All.SendAsync("StudentUpdated", student);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studToDelete = this.sl.Read(id);
            this.sl.Delete(id);
            this.hub.Clients.All.SendAsync("StudentDeleted", studToDelete);
        }
    }
}