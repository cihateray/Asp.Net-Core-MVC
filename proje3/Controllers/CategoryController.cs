using Microsoft.AspNetCore.Mvc;
using proje3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proje3.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace proje3.Controllers
{
	public class CategoryController : Controller
	{
		CategoryRepository categoryRepository = new CategoryRepository();
		public IActionResult Index()
		{
			return View(categoryRepository.TList());
		}
		[HttpGet]
		public IActionResult CategoryAdd()
		{
			return View();

		}
		[HttpPost]
		public IActionResult CategoryAdd(Category p)
		{
			if (!ModelState.IsValid)
			{
				return View("CategoryAdd");
			}
			categoryRepository.TAdd(p);
			return RedirectToAction("Index");
		}
		public IActionResult CategoryGet (int id)
		{
			var x = categoryRepository.TGet(id);
			Category ct = new Category()
			{
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName,
				CategoryDescription = x.CategoryDescription,
				CategoryStatus = x.CategoryStatus
			};
			return View(ct);
		}
		[HttpPost]
		public IActionResult CategoryUpdate(Category p)
		{
			var x = categoryRepository.TGet(p.CategoryId);
			x.CategoryName = p.CategoryName;
			x.CategoryDescription = p.CategoryDescription;
			x.CategoryStatus = true;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
		public IActionResult CategoryDelete(int id)
		{
			var x = categoryRepository.TGet(id);
			x.CategoryStatus = false;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
	}
}
