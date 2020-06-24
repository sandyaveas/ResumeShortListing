using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO
{
	public class PersonalDetail
	{
		[Required]
		[Key]
		public int CandidateId { get; set; }

		[Range(0,1)]
		public string Gender { get; set; }

		public DateTime BirthDate { get; set; }

		[Range(0,2)]
		public string BloodGroup { get; set; }

		[Range(0,2)]
		public string MaritalStatus { get; set; }

		[Range(0,1000)]
		public string Address { get; set; }

		[Range(0,100)]
		public string City { get; set; }

		[Range(0,10)]
		public string Pincode { get; set; }

		[Range(0,100)]
		public string State { get; set; }

		public DateTime Created { get; set; }

		public DateTime LastUpdated { get; set; }
	}
}
