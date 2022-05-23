using LibraryAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class BookEntity : Entity
    {
        public string Title { get; set; }
        public Guid CurrentStatusId { get; set; }
        public StatusHistoryEntity CurrentStatus { get; set; }
        public string Language { get; set; }
        public DateTime? PublicationDate { get; set; }
        public BookGenres? Genre { get; set; }
        public int? PageNumber { get; set; }
        public virtual BookAuthorEntity BookAuthor { get; set; }

        public void SetBeginnerStatus() 
        {
            CurrentStatus = new StatusHistoryEntity()
            {
                BookId = Id,
                ModifiedDate = DateTime.Now,
                Status = Statuses.InStock
            };

            CurrentStatus.GenerateId();
        }

        public void ChangeStatus(StatusHistoryEntity statusHistory)
        {
            CurrentStatusId = statusHistory.Id;
        }
    }
}
