using Microsoft.AspNetCore.Mvc;
using Book_Library_Manager.Interfaces;
using Book_Library_Manager.Core.Models.DTOs;
using Ardalis.Result;

namespace Book_Library_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var result = await _bookService.GetAllBooks();

            if (!result.IsSuccess)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            var result = await _bookService.GetBookById(id);

            if (!result.IsSuccess)
            {
                if (result.IsNotFound()) return NotFound();
            }

            return Ok(result.Value);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutBook(Guid id, [FromBody] UpdateBookDto book)
        {
            var result = await _bookService.UpdateBook(id, book);

            if (!result.IsSuccess)
            {
                if (result.IsNotFound()) return NotFound();
                if (result.IsInvalid()) return BadRequest(result.Errors);
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBookDto>> PostBook([FromBody] CreateBookDto book)
        {
            var result = await _bookService.AddBook(book);

            if (!result.IsSuccess)
            {
                if (result.IsInvalid()) return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.Value.Id }, result.Value);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBook(id);
            if (!result.IsSuccess)
            {
                 if (result.IsNotFound()) return NotFound();
            }

            return NoContent();
        }
    }
}
