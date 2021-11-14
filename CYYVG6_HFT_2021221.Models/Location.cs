﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [MaxLength (100)]
        public string Address { get; set; }

        public bool? IsNearDorm { get; set; }

        public virtual Faculty Faculty { get; set; }

        [ForeignKey(nameof(Faculty))]
        public int FacultyId { get; set; }

    }
}
