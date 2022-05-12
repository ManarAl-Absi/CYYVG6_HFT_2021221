using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Models
{
    [Table("Emlpoyees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [MaxLength (100)]
        public string FulName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Position{ get; set; }   //Professor, Lecturer, manager, Customer Service, Programmer
        public int Salary { get; set; }

        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey(nameof(Faculty))]
        public int FacultyId { get; set; }

    }
}
