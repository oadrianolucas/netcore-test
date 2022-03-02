#nullable disable
using System;
using System.Collections.Generic;

namespace Einstein.Models
{
    public partial class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}