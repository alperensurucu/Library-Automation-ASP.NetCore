using Library.Context;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Library.RepositoryPattern.Interfaces;
using Library.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Library.Areas.Management.Controllers
{
	[Area("Management")]
	[Authorize(Policy = "AdminPolicy")]
	public class BookTypeController : Controller
	{
		IRepository<BookType> _repoBookType;

		public BookTypeController(IRepository<BookType> repoBookType)
		{
			_repoBookType = repoBookType;
		}
		/*	IBookTypeRepository _repoBookType;

			public BookTypeController(IBookTypeRepository repoBookType)
			{
				_repoBookType = repoBookType;
			}
		*/
		public IActionResult BookTypeList()
		{
			List<BookType> bookTypes = _repoBookType.GetAll();
			return View(bookTypes);
		}
		/*	public IActionResult BookTypeList()
			{
				List<BookTypeDto> bookTypes = _repoBookType.SelectBookTypeDto();
				return View(bookTypes);
			}
		*/
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(BookType bookType)
		{
			_repoBookType.Add(bookType);
			return RedirectToAction("BookTypeList","BookType",new {area="Management"});
		}

		public IActionResult Edit(int id)
		{
			BookType bookType = _repoBookType.GetById(id);
			return View(bookType);
		}

		[HttpPost]
		public IActionResult Edit(BookType bookType)
		{
			_repoBookType.Update(bookType);
			return RedirectToAction("BookTypeList", "BookType", new { area = "Management" });
		}

		public IActionResult HardDelete(int id)
		{
			_repoBookType.SpecialDelete(id);
			return RedirectToAction("BookTypeList", "BookType", new { area = "Management" });
		}
	}
}