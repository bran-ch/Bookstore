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
        public ActionResult<AuthorModel> Post([FromBody] AuthorModel authorModel)
        {
            try
            {
                var created = _authorService.CreateAuthor(authorModel);

                return Ok(created);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return Problem("Error", null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{authorId}")]
        public ActionResult<AuthorModel> Put(int authorId, [FromBody] AuthorModel authorModel)
        {
            if (authorId != authorModel.AuthorId)
            {
                return BadRequest();
            }

            try
            {
                var updated = _authorService.UpdateAuthor(authorId, authorModel);

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

        [HttpDelete("{authorId}")]
        public ActionResult<AuthorModel> Delete(int authorId)
        {
            try
            {
                var deleted = _authorService.DeleteAuthor(authorId);

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
