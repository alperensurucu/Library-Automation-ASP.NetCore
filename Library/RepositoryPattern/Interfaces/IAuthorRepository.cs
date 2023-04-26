using Library.Dto;
using Library.Models;
using System.Collections.Generic;

namespace Library.RepositoryPattern.Interfaces
{
	public interface IAuthorRepository:IRepository<Author>
	{
		List<AuthorDto> SelectAuthorDto();
	}
}
