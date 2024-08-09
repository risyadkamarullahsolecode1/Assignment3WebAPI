using Asp.Versioning;
using Assignment3WebAPI.Interfaces;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetAllBook()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        /// <summary>
        /// You can Add Books for Library here.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/Book
        ///     {
        ///         "id": 0,
        ///         "title": "string",
        ///         "author": "string",
        ///         "publicationYear": 0,
        ///         "isbn": "string"
        ///     }
        /// </remarks>
        /// <param name="Add Book"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public IActionResult AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookService.AddBook(book);
            return Ok(book);
        }
        /// <summary>
        /// You can Update Books for Library here.
        /// </summary>

        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/v1/Book
        ///     {
        ///         "id": 1,
        ///         "title": "string",
        ///         "author": "string",
        ///         "publicationYear": 2012,
        ///         "isbn": "string"
        ///     }
        /// </remarks>
        /// <param name="Add Book"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult UpdateBook(int id, [FromBody]Book updatedBook)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) {
                return NotFound();
            }
            _bookService.UpdateBook(id, updatedBook);
            return Ok(book);
        }
        /// <summary>
        /// You can Delete Book for Library here.
        /// </summary>

        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/Book/{id}
        ///     
        /// </remarks>
        /// <param name="Add Book"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(id);
            return Ok("Buku Telah dihapus");
        }
    }
}
