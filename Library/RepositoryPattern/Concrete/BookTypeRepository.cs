using Library.Context;
using Library.Dto;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.RepositoryPattern.Concrete
{
	public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
	{
		public BookTypeRepository(MyDbContext db) : base(db)
		{
		}
		
		public List<BookTypeDto> SelectBookTypeDto()
		{
			return table.Where(x => x.Status != Enum.DataStatus.Deleted).Select(x =>
			new BookTypeDto()
			{
				ID= x.ID,
				Name = x.Name
			}).ToList();
		}

		
	}
}
