
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultyLogic fl;
        IHubContext<SignalRHub> hub;
        public FacultyController(IFacultyLogic fl, IHubContext<SignalRHub> hub)
        {
            this.fl = fl;
            this.hub = hub;
        }

        //Get All
        [HttpGet]
        public IEnumerable<Faculty> Get()
        {
            return this.fl.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Faculty Get(int id)
        {
            return this.fl.Read(id);
        }

       // Post
        [HttpPost]
        public void Post([FromBody] Faculty faculty)
        {
            this.fl.Create(faculty);
            this.hub.Clients.All.SendAsync("FacultyCreated", faculty);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Faculty faculty)
        {
            this.fl.Update(faculty);
            this.hub.Clients.All.SendAsync("FacultyUpdated", faculty);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var facToDelete = this.fl.Read(id);
            this.fl.Delete(id);
            this.hub.Clients.All.SendAsync("FacultyDeleted", facToDelete);
        }
    }
}