﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.Data.Models
{
	public class Food
	{
		public int FoodId { get; set; }
		public string FoodName { get; set; }
		public string FoodDescription { get; set; }
		public double FoodPrice { get; set; }
		public string FoodImageUrl { get; set; }
		public int FoodStock { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
