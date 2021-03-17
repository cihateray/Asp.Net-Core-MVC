using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.Data.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		//[Required(ErrorMessage ="Category Name Not Empty!")]
		[StringLength(20,ErrorMessage ="Please only enter 3-20 characters",MinimumLength =3)]
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public bool CategoryStatus { get; set; }
		public List<Food> Foods { get; set; }
	}
}
