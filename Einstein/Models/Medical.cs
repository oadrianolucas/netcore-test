#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Einstein.Models
{
    public partial class Medical
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public int Cfm { get; set; }
        [Required]
        public DateTime Birth { get; set; }
    }
}