using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO
{
	public class JobExperience
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		public int CandidateId { get; set; }

		[Required]
		[Range(0,255)]
		public string Designation { get; set; }

		[Required]
		[Range(0,1000)]
		public string Organization { get; set; }

		[Required]
		public bool IsCurrent { get; set; }

		[Required]
		public int StartYear { get; set; }

		[Required]
		public int StartMonth { get; set; }

		public int EndYear { get; set; }

		public int EndMonth { get; set; }

		public decimal CurrentSalary { get; set; }

		public int NoticePeriod { get; set; }

		[Range(0,1000)]
		public string JobProfile { get; set; }

		public DateTime Created { get; set; }

		public DateTime LastUpdated { get; set; }
	}
}
