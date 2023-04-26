
using Library.Dto;
using Library.Models;
using System.Collections.Generic;

namespace Library.RepositoryPattern.Interfaces
{
	public interface IBookTypeRepository:IRepository<BookType>
	{
		
		List<BookTypeDto> SelectBookTypeDto();
	}
}
    //duruma göre açabilirsin .