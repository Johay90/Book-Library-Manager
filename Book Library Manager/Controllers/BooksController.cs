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

        // GET: api/Books/search?query=programming
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks([FromQuery] string query)
        {
            var result = await _bookService.SearchBooks(query);

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
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto book)
        {
            var result = await _bookService.UpdateBook(id, book);

            if (!result.IsSuccess)
            {
                if (result.IsNotFound()) return NotFound();
                if (result.IsInvalid()) return BadRequest(result.Errors);
            }

            return NoContent();
        }

        // PATCH: api/Books/5/progress
        [HttpPatch("{id}/progress")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> UpdateBookProgress(Guid id, [FromBody] UpdateProgressDto progressDto)
        {
            if (progressDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookService.UpdateReadingProgress(id, progressDto.Progress);
            if (!result.IsSuccess)
            {
                if (result.IsNotFound()) return NotFound();
            }

            return Ok(result.Value);
        }

        // POST: api/Books/{id}/borrow
        [HttpPost("{id}/borrow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<BookDto>> BorrowBook(Guid id, [FromBody] BorrowBookDto borrowDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookService.CheckOutBook(id, borrowDto);
            if (!result.IsSuccess)
            {
                if (result.Status == ResultStatus.NotFound) return NotFound();
                if (result.Status == ResultStatus.Conflict) return Conflict(result.Errors);
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.Value.Id }, result.Value);
        }

        // POST: api/Books/{id}/borrow
        [HttpPost("{id}/return")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> ReturnBook(Guid id)
        {
            var result = await _bookService.ReturnBook(id);
            if (!result.IsSuccess)
            {
                if (result.Status == ResultStatus.NotFound) return NotFound();
                if (result.Status == ResultStatus.Invalid) return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.Value.Id }, result.Value);
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBookDto>> AddBook([FromBody] CreateBookDto book)
        {
            var result = await _bookService.AddBook(book);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
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
