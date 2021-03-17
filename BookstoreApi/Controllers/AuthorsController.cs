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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService authorService, ILogger<AuthorsController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorModel>> GetAll()
        {
            var authors = _authorService.GetAuthors();

            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorModel> GetById(int authorId)
        {
            var found = _authorService.GetAuthor(authorId);

            if (found is null)
            {
                return NotFound();
            }

            return found;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AuthorModel AuthorModel)
        {
            try
            {
                _authorService.CreateAuthor(AuthorModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{authorId}")]
        public ActionResult Put(int authorId, [FromBody] AuthorModel authorModel)
        {
            if (authorId != authorModel.AuthorId)
            {
                return BadRequest();
            }

            try
            {
                _authorService.UpdateAuthor(authorId, authorModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }

            return NoContent();
        }

        [HttpDelete("{authorId}")]
        public ActionResult Delete(int authorId)
        {
            try
            {
                _authorService.DeleteAuthor(authorId);
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
