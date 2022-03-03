#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Einstein.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        [Required]
        public DateTime Schedule { get; set; }
        [Required]
        public int IdMedical { get; set; }
        [Required]
        public int IdPatient { get; set; }
    }
}