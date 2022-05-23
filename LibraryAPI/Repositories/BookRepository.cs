using LibraryAPI.Contexts;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(BookEntity book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public IEnumerable<BookEntity> Get(int page, int limit)
        {
            return context.Books.OrderBy(b => b.Id).Skip((page - 1) * limit).OrderBy(b => b.Title).Take(limit);
        }

        public BookEntity GetById(Guid bookId)
        {
            return context.Books
                .Include(b => b.CurrentStatus)
                .FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<StatusHistoryEntity> GetBookStatuses(Guid bookId)
        {
            return context.StatusHistories.Where(s => s.BookId == bookId);
        }

        public BookEntity GetByTitle(string title)
        {
            return context.Books.FirstOrDefault(b => b.Title == title);
        }

        public StatusHistoryEntity GetLastStatusByBookId(Guid bookId)
        {
            return context.StatusHistories.Where(s => s.BookId == bookId).OrderByDescending(s => s.ModifiedDate).First();
        }

        public BookAuthorEntity GetAuthorByBookId(Guid bookId)
        {
            return context.BookAuthors.FirstOrDefault(a => a.BookId == bookId);
        }

        public void AddStatus(StatusHistoryEntity statusHistory)
        {
            context.StatusHistories.Add(statusHistory);
             context.SaveChanges();
        }

        public void UpdateBook(BookEntity book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }
    }
}
