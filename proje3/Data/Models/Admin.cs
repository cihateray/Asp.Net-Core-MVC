using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.Data.Models
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }

		[StringLength(20)]
		public string AdminName { get; set; }

		[StringLength(8)]
		public string AdminPassword { get; set; }

		[StringLength(1)]
		public string AdminRole { get; set; }
	}
}
