using Library.Models.MetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Models
{
    [ModelMetadataType(typeof(AuthorMetaData))]
    public class Author:BaseEntity
    {
		
		public string FirstName { get; set; }
      //  [Required]
        public string LastName { get; set; }

        //Relational Property
        public List<Book> Books { get; set; }

    }
}
