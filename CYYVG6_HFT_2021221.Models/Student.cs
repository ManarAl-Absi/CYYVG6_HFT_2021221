﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey(nameof(Faculty))]
        public int FacultyId { get; set; }

    }
}
