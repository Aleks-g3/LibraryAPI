using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class BookAuthorEntity
    {
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
