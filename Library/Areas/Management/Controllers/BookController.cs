using Library.Context;
using Library.Dto;
using Library.Enum;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Library.Areas.Management.Controllers
{
	[Area("Management")]
	[Authorize(Policy = "AdminPolicy")]
	public class BookController : Controller
	{
		MyDbContext _db;
		IBookRepository _repoBook;
		IAuthorRepository _repoAuthor;
	//	IBookTypeRepository _repoBookType;     Sonradan eklenenler .

		public BookController(MyDbContext db,
			IBookRepository repoBook,
			IAuthorRepository repoAuthor)
	//		IBookTypeRepository repoBookType)    Sonradan eklenenler. 
		{ 
			_db= db;
			_repoBook= repoBook;
			_repoAuthor= repoAuthor;
	//		_repoBookType= repoBookType;      Sonradan eklenenler. 
		}
		public IActionResult BookList()
		{
			List<Book> books = _repoBook.GetBooks();
			return View(books);
		}
		public IActionResult Create()
		{
			List<AuthorDto> authors = _repoAuthor.SelectAuthorDto();

			List<BookTypeDto> bookTypes = _db.BookTypes.Where(x => x.Status != Enum.DataStatus.Deleted).Select(x =>
			new BookTypeDto()                                                 //burada Enums olmadı  ?.
			{
				ID= x.ID,
				Name= x.Name
			}).ToList();

			return View((new Book(), authors, bookTypes));
			/*
					List<BookTypeDto> bookTypes = _repoBookType.SelectBookTypeDto();    bunlar yerine üstü yazdım .   
					return View((new Book(), authors, bookTypes));                          Sonradan eklenenler. değiştirilebilir.
			*/
		}
		[HttpPost]
		public IActionResult Create([Bind(Prefix = "Item1")] Book book)
		{
			if (!ModelState.IsValid)
			{
				List<AuthorDto> authors = _repoAuthor.SelectAuthorDto();

				List<BookTypeDto> bookTypes = _db.BookTypes.Where(x => x.Status != Enum.DataStatus.Deleted).Select(x =>
				new BookTypeDto()                                                 //burada Enums olmadı  ?.
				{
					ID= x.ID,
					Name= x.Name
				}).ToList();

				return View((book, authors, bookTypes));
				;
			}
			_repoBook.Add(book);
			return RedirectToAction("BookList","Book",new {area="Management"});
		}

		/*

		public IActionResult Edit(int id)
		{
			List<AuthorDto> authors = _db.Authors.Where(x => x.Status != Enum.DataStatus.Deleted).Select(x =>
			new AuthorDto()
			{

				FirstName=x.FirstName,
				LastName=x.LastName,
				ID =x.ID
			}).ToList();

			List<BookTypeDto> bookTypes = _db.BookTypes.Where(x => x.Status != Enum.DataStatus.Deleted).Select(x =>
			new BookTypeDto()
			{
				ID= x.ID,
				Name = x.Name
			}).ToList();

			Book book = _db.Books.Find(id);
			

			return View((book, authors, bookTypes));
		}

		[HttpPost]
		public IActionResult Edit([Bind(Prefix = "Item1")] Book book)
		{ 
		//	book.Status = Enum.DataStatus.Updated;       //bunlar zaten kapalıydı
		//	book.ModifiedDate= DateTime.Now;              //bunlar zaten kapalıydı
			_db.Books.Update(book);
			_db.SaveChanges();
			return RedirectToAction("BookList");
		}

		public IActionResult HardDelete(int id)
		{
			Book books = _db.Books.Find(id);
			_db.Books.Remove(books);
			_db.SaveChanges();
			return RedirectToAction("BookList");
		}
	*/
	}
}
