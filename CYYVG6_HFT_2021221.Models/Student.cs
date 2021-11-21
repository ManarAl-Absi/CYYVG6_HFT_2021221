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
        public string Major { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public bool? SpeaksHungarian { get; set; }
        public int TitutionPrice { get; set; }

        [NotMapped]
        public string MainData => $"[{StudentId}] : {FulName} : {Gender} : {Nationality} : {Major}  (Age: {Age}) (Number of faculties he or she attends: {Faculties.Count()})";

        [NotMapped]
        public virtual ICollection<Faculty> Faculties { get; set; }
        public Student()
        {
            this.Faculties = new HashSet<Faculty>();
        }
    }
}
