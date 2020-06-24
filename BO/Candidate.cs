using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BO
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }

        public string Password { get; set; }

        [Display(Name="Experience In Years")]
        public int ExpYear { get; set; }

        [Display(Name = "Experience In Months")]
        public int ExpMonth { get; set; }

        public string Location { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime LoggedInAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdated { get; set; }
    }
}
