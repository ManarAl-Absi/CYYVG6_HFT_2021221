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
    
        [Table("Faculty")]
        public class Faculty
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int FacultyId { get; set; }

            [MaxLength(100)]
            public string FacultyName { get; set; }
            public string FacultyAddress { get; set; }
             [JsonIgnore]

        public virtual ICollection<Employee> Employees { get; set; }
            [JsonIgnore]

        public virtual ICollection<Student> Students { get; set; }

           [NotMapped]
            public string MainData => $"[{FacultyId}] : {FacultyName}  (Faculty Address: {FacultyAddress})";

        }


}
