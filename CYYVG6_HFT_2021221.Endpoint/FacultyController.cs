
using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultyLogic fl;
        public FacultyController(IFacultyLogic fl)
        {
            this.fl = fl;
        }

        //Get All
        [HttpGet]
        public IEnumerable<Faculty> Get()
        {
            return fl.GetAll();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Faculty Get(int id)
        {
            return fl.Read(id);
        }

       // Post
        [HttpPost]
        public void Post([FromBody] Faculty faculty)
        {
            fl.Create(faculty);
        }

        // Put
        [HttpPut]
        public void Put([FromBody] Faculty faculty)
        {
            fl.Update(faculty);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fl.Delete(id);
        }
    }
}