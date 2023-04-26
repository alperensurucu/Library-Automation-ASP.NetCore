using System.Collections.Generic;

namespace Library.Models
{
    public class BookType : BaseEntity

    {
        public string Name { get; set; }

        //Relational Property

        public List<Book> Books { get; set; }





    }
}
