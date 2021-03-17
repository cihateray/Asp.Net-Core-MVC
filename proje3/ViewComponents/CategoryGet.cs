using Microsoft.AspNetCore.Mvc;
using proje3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.ViewComponents
{
	public class CategoryGet:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepository categoryRepository = new CategoryRepository();
			var categoryList = categoryRepository.TList();
			return View(categoryList);
		}
	}
}
