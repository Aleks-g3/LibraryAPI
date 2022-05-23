using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Providers;
using LibraryAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IBookProvider bookProvider;

        public BookService(IBookRepository bookRepository, IBookProvider bookProvider)
        {
            this.bookRepository = bookRepository;
            this.bookProvider = bookProvider;
        }

        public async Task<Guid> AddAsync(BookEntity book)
        {
            var existBook = bookRepository.GetByTitle(book.Title);

            if (existBook != null)
            {
                throw new Exception("Book with title exist");
            }

            book.GenerateId();

            book.SetBeginnerStatus();

            await bookRepository.AddAsync(book);

            return book.Id;
        }

        public IEnumerable<BookEntity> GetBooks(int page, int limit)
        {
            return bookRepository.Get(page, limit);
        }

        public BookDetails GetBookDetails(Guid bookId)
        {
            var book = GetBookById(bookId);

            var bookPrice = GetBookPriceById(bookId);

            book.BookAuthor = bookRepository.GetAuthorByBookId(bookId);

            return BookDetails.Create(book, bookPrice);
        }

        

        public IEnumerable<StatusHistoryEntity> GetBookStatuses(Guid bookId)
        {
            GetBookById(bookId);

            return bookRepository.GetBookStatuses(bookId);
        }

        private BookEntity GetBookById(Guid bookId)
        {
            var book = bookRepository.GetById(bookId);

            if(book == null)
            {
                throw new Exception("Book not exist");
            }

            return book;
        }

        private BookPrice GetBookPriceById(Guid bookId)
        {
            var bookPrice = bookProvider.GetPriceById(bookId);
            return bookPrice.Result;
        }

        public void UpdateStatus(Guid bookId, Statuses status)
        {
            var book = GetBookById(bookId);

            var statusHistory = StatusHistoryEntity.Create(book, status);

            statusHistory.GenerateId();

            bookRepository.AddStatus(statusHistory);

            book.ChangeStatus(statusHistory);

            bookRepository.UpdateBook(book);
        }
    }
}
