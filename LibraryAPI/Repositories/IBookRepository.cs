using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(BookEntity book);
        IEnumerable<BookEntity> Get(int page, int limit);
        BookEntity GetById(Guid bookId);
        BookEntity GetByTitle(string title);
        IEnumerable<StatusHistoryEntity> GetBookStatuses(Guid bookId);
        StatusHistoryEntity GetLastStatusByBookId(Guid bookId);
        BookAuthorEntity GetAuthorByBookId(Guid bookId);
        void AddStatus(StatusHistoryEntity statusHistory);
        void UpdateBook(BookEntity book);
    }
}
