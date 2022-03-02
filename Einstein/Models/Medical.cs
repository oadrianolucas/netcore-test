#nullable disable
using System;
using System.Collections.Generic;

namespace Einstein.Models
{
    public partial class Medical
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Cfm { get; set; }
        public DateTime Birth { get; set; }
    }
}