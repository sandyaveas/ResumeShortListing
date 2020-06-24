using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BO
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public int CandidateId { get; set; }       

        public string SkillName { get; set; }

        public int ExpYear { get; set; }

        public int ExpMonth { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
