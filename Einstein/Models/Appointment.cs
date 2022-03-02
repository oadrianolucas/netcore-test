#nullable disable
using System;
using System.Collections.Generic;

namespace Einstein.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public int IdMedical { get; set; }
        public int IdPatient { get; set; }
    }
}