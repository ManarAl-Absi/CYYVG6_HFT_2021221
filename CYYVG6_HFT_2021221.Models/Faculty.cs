using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

            public virtual Student Student { get; set; }

            [ForeignKey(nameof(Student))]
            public int StudentId { get; set; }

        }
    }


}
