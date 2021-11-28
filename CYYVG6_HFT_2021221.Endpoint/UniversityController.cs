


using CYYVG6_HFT_2021221.Logic;
using CYYVG6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CYYVG6_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        IUniversityLogic ul;
        public UniversityController(IUniversityLogic ul)
        {
            this.ul = ul;
        }

        //Get All
        [HttpGet]
        public IList<Faculty> Get()
        {
            return ul.GetAllFaculties();
        }

        //Get One From ID
        [HttpGet("{id}")]
        public Faculty Get(int id)
        {
            return ul.GetOneFaculty(id);
        }

        //Post
        //[HttpPost("{id}")]
        //public void Post( int id, string facultyName)
        //{
        //    ul.ChangeFacultyName(id, facultyName);
        //}
    }
}