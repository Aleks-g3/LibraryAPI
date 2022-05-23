using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public LibraryController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get list of books (Id and Title)
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="limit">Number of books on each page</param>
        /// <returns>List of Books sorted by book title</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks(int page = 0, int limit = 10)
        {
            var books = bookService.GetBooks(page, limit);
            return Ok(mapper.Map<IEnumerable<Book>>(books));
        }

        /// <summary>
        /// Get details of a book
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Details of a book</returns>
        [HttpGet("details/{bookId}")]
        public ActionResult<BookDetails> GetBookDetails([FromRoute] Guid bookId)
        {
            var bookDetails = bookService.GetBookDetails(bookId);
            return Ok(bookDetails);
        }

        /// <summary>
        /// Get history of book statuses sorted by date (oldest to newest)
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>List of BookStatuses</returns>
        [HttpGet("statuses/{bookId}")]
        public ActionResult<IEnumerable<BookStatus>> GetBookStatuses([FromRoute] Guid bookId)
        {
            var statuses = bookService.GetBookStatuses(bookId);
            return Ok(mapper.Map<IEnumerable<BookStatus>>(statuses));
        }

        /// <summary>
        /// Insert new book to the library
        /// </summary>
        /// <param name="insertBookDto">Book to create details</param>
        /// <returns>Id of new book</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> InsertBook([FromBody] InsertBookDto insertBookDto)
        {
            var book = mapper.Map<BookEntity>(insertBookDto);
            var bookId = await bookService.AddAsync(book);
            return Ok(bookId);
        }

        /// <summary>
        /// Change status of a book
        /// </summary>
        /// <param name="bookId">Bookd Id</param>
        /// <param name="status">New book status</param>
        [HttpPost("status/{bookId}")]
        public ActionResult ChangeBookStatus([FromRoute] Guid bookId, [FromBody] Statuses status)
        {
            return Ok();
        }
    }
}
