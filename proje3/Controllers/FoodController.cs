using Microsoft.AspNetCore.Mvc;
using proje3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proje3.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace proje3.Controllers
{
	public class FoodController : Controller
	{
		Context c = new Context();
		FoodRepository foodRepository = new FoodRepository();
		public IActionResult Index(int page = 1)
		{		
			return View(foodRepository.TList("Category").ToPagedList(page, 5));
		}
		[HttpGet]
		public IActionResult FoodAdd()
		{
			List<SelectListItem> values = (from x in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryId.ToString()
										   }).ToList();
			ViewBag.v = values;
			return View();
		}
		[HttpPost]
		public IActionResult FoodAdd(Food p)
		{
			foodRepository.TAdd(p);
			return RedirectToAction("Index");
		}
		public IActionResult FoodDelete(int id)
		{
			foodRepository.TDelete(new Food { FoodId = id });
			return RedirectToAction("Index");
		}
		public IActionResult FoodGet(int id)
		{
			var x = foodRepository.TGet(id);
			Food f = new Food()
			{
				FoodId=x.FoodId,
				CategoryId = x.CategoryId,
				FoodName = x.FoodName,
				FoodDescription = x.FoodDescription,
				FoodPrice = x.FoodPrice,
				FoodImageUrl = x.FoodImageUrl,
				FoodStock = x.FoodStock
			};	
			List<SelectListItem> values = (from y in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = y.CategoryName,
											   Value = y.CategoryId.ToString()
										   }).ToList();
			ViewBag.v = values;
			return View(f);
		}
		[HttpPost]
		public IActionResult FoodUpdate(Food p)
		{
			var x = foodRepository.TGet(p.FoodId);
			x.FoodName = p.FoodName;
			x.FoodPrice = p.FoodPrice;
			x.FoodStock = p.FoodStock;
			x.CategoryId = p.CategoryId;
			x.FoodDescription = p.FoodDescription;
			x.FoodImageUrl = p.FoodImageUrl;
			foodRepository.TUpdate(x);
			return RedirectToAction("Index");
		}

	}
}
