using LibraryAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class StatusHistoryEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Statuses Status { get; set; }
    }
}
