using Microsoft.AspNetCore.Mvc;
using proje3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.ViewComponents
{
	public class FoodGet : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodList = foodRepository.TList();
			return View(foodList);
		}
	}
}
