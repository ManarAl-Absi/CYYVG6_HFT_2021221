using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FulName { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public bool? SpeaksHungarian { get; set; }
        public bool? HasScholarship { get; set; }

        [NotMapped]
        public string MainData => $"[{StudentId}] : {FulName} : {Nationality} : {Majors}  (Age: {Age}) (Number of faculties he or she attends: {Faculties.Count()})";

        [NotMapped]
        public virtual ICollection<Faculty> Faculties { get; set; }
        public Student()
        {
            Faculties = new HashSet<Faculty>();
        }


    }
}
