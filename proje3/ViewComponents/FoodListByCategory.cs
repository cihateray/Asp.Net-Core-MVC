using Microsoft.AspNetCore.Mvc;
using proje3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.ViewComponents
{
	public class FoodListByCategory : ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{

			FoodRepository foodRepository = new FoodRepository();
			var foodList = foodRepository.List(x=>x.CategoryId==id);
			return View(foodList);
		}
	}
}
