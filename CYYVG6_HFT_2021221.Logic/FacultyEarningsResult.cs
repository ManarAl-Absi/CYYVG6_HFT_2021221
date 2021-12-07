using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    public class FacultyEarningsResult
    {
        public int facultyId { get; set; }
        public string facultyName { get; set; }
        public string facultyAddress { get; set; }
        public int TotalEarnings { get; set; }

        public override string ToString()
        {
            return $"Faculty's ID: {this.facultyId}, Faculty name: {this.facultyName}, Faculty address: {this.facultyAddress}.";
        }
    }
}
