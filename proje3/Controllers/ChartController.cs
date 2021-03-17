using Microsoft.AspNetCore.Mvc;
using proje3.Data;
using proje3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje3.Controllers
{
	public class ChartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Index1()
		{
			return View();
		}
		public IActionResult VisualizeProductResult1()
		{
			return Json(FoodList());
		}
		public List<Class1> FoodList()
		{
			List<Class1> cs1 = new List<Class1>();
			using(var c= new Context())
			{
				cs1 = c.Foods.Select(x => new Class1
				{
					foodName = x.FoodName,
					foodStock = x.FoodStock
				}).ToList();
			}
			return cs1;
		}
		public IActionResult Statistics()
		{
			Context c = new Context();

			var deger1 = c.Categories.Count();
			ViewBag.d1 = deger1;

			var deger2 = c.Foods.Count();
			ViewBag.d2 = deger2;

			var deger3 = c.Foods.Where(x=> x.CategoryId== c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryId).FirstOrDefault()).Count();
			ViewBag.d3 = deger3;

			var deger4 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault()).Count();
			ViewBag.d4 = deger4;

			var deger5 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(x => x.CategoryName == "Legumes").Select(y => y.CategoryId).FirstOrDefault()).Count();
			ViewBag.d5 = deger5;

			var deger6 = c.Foods.Sum(x => x.FoodStock);
			ViewBag.d6 = deger6;

			var deger7 = c.Foods.OrderByDescending(x => x.FoodStock).Select(y => y.FoodName).FirstOrDefault();
			ViewBag.d7 = deger7;

			var deger8 = c.Foods.OrderBy(x => x.FoodStock).Select(y => y.FoodName).FirstOrDefault();
			ViewBag.d8 = deger8;

			var deger9 = c.Foods.Average(x => x.FoodPrice).ToString("0.00");
			ViewBag.d9 = deger9;

			
			var deger10p = c.Foods.Where(x => x.Category.CategoryName =="Fruits").Select(y => y.CategoryId).FirstOrDefault();
			var deger10 = c.Foods.Where(x => x.CategoryId == deger10p).Sum(x => x.FoodStock);
			ViewBag.d10 = deger10;

			var deger11p = c.Foods.Where(x => x.Category.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
			var deger11 = c.Foods.Where(x => x.CategoryId == deger11p).Sum(x => x.FoodStock);
			ViewBag.d11 = deger11;

			var deger12 = c.Foods.OrderByDescending(x => x.FoodPrice).Select(y => y.FoodName).FirstOrDefault();
			ViewBag.d12 = deger12;

			return View();
		}
	}
}
