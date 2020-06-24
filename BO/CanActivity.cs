using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO
{
	public class CanActivity
	{
		[Required]
		[Key]
		public int Id { get; set; }

		public int CandidateId { get; set; }

		[Range(0,200)]
		public string TabName { get; set; }

		[Range(0,200)]
		public string FieldName { get; set; }

		public DateTime Modified { get; set; }
	}
}
