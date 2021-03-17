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
        public ActionResult Post([FromBody] BookModel bookModel)
        {
            try
            {
                _bookService.CreateBook(bookModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{bookId}")]
        public ActionResult Put(int bookId, [FromBody] BookModel bookModel)
        {
            if (bookId != bookModel.BookId)
            {
                return BadRequest();
            }

            try
            {
                _bookService.UpdateBook(bookId, bookModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }

            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public ActionResult Delete(int bookId)
        {
            try
            {
                _bookService.DeleteBook(bookId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }

            return NoContent();
        }
    }
}
