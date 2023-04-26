using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Library.Areas.Management.Controllers
{
	[Area("Management")]
	[Authorize(Policy ="AdminPolicy")]  // kimlik kontorlü

	public class AuthorController : Controller
	{
		List<Author> aa = new List<Author>
		{
			new Author(){ID = 1}
		};

		IAuthorRepository _repoAuthor;
		public AuthorController(IAuthorRepository repoAuthor)
		{

			_repoAuthor= repoAuthor;
		}
		

		public IActionResult AuthorList()
		{
			List<Author> authors = _repoAuthor.GetActives(); //değiştirdim  .
			return View(authors);
			/*List<Author> authors = _repoAuthor.GetAll();
			return View(authors);*/
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Author author)
		{
			if (!ModelState.IsValid)
			{
				return View(author);
			}
			_repoAuthor.Add(author);

			return RedirectToAction("AuthorList", "Author", new {area="Management"});
		}
		public IActionResult Edit(int id)
		{
			Author author = _repoAuthor.GetById(id);
			return View(author);
		}
		[HttpPost]
		public IActionResult Edit(Author author)
		{
			_repoAuthor.Update(author);
			return RedirectToAction("AuthorList", "Author", new { area = "Management" });
		}

		public IActionResult Delete(int id)
		{
			_repoAuthor.Delete(id);
			return RedirectToAction("AuthorList", "Author", new { area = "Management" });
		}
		/*
		public IActionResult HardDelete(int id)
		{
			_repoAuthor.SpecialDelete(id);
			return RedirectToAction("AuthorList");
		}
		*/
	}
}
