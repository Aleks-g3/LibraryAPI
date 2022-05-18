using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CurrentStatusId { get; set; }
        public StatusHistoryEntity CurrentStatus { get; set; }
        public string Language { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Genre { get; set; }
        public int? PageNumber { get; set; }
        public BookAuthorEntity BookAuthor { get; set; }
        public StatusHistoryEntity StatusHistory { get; set; }
    }
}
