using LibraryAPI.Enums;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<Guid> AddAsync(BookEntity book);
        IEnumerable<StatusHistoryEntity> GetBookStatuses(Guid bookId);
        BookDetails GetBookDetails(Guid bookId);
        IEnumerable<BookEntity> GetBooks(int page, int limit);
        void UpdateStatus(Guid bookId, Statuses status);
    }
}
