using System;
using System.Collections.Generic;
using System.Net;
using BookstoreApi.Models;
using BookstoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookstoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> GetAll()
        {
            var books = _bookService.GetBooks();

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public ActionResult<BookModel> GetById(int bookId)
        {
            var found = _bookService.GetBook(bookId);

            if (found is null)
            {
                return NotFound();
            }

            return found;
        }

        [HttpPost]
        public ActionResult<BookModel> Post([FromBody] BookModel bookModel)
        {
            try
            {
                var created = _bookService.CreateBook(bookModel);

                return Ok(created);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{bookId}")]
        public ActionResult<BookModel> Put(int bookId, [FromBody] BookModel bookModel)
        {
            if (bookId != bookModel.BookId)
            {
                return BadRequest();
            }

            try
            {
                var updated = _bookService.UpdateBook(bookId, bookModel);

                if (updated is null)
                {
                    return BadRequest();
                }

                return Ok(updated);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{bookId}")]
        public ActionResult<BookModel> Delete(int bookId)
        {
            try
            {
                var deleted = _bookService.DeleteBook(bookId);

                if (deleted is null)
                {
                    return BadRequest();
                }

                return Ok(deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
