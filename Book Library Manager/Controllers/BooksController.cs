using Microsoft.AspNetCore.Mvc;
using Book_Library_Manager.Interfaces;
using Book_Library_Manager.Core.Models.DTOs;

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
            var books = await _bookService.GetAllBooks();

            if (!books.Any())
            {
                return NoContent();
            }

            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            var book = await _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutBook(Guid id, [FromBody] UpdateBookDto book)
        {
            var bookEsists = await _bookService.GetBookById(id);

            if (bookEsists is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // TODO annotate model
            {
                return BadRequest(ModelState);
            }

            await _bookService.UpdateBook(id, book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBookDto>> PostBook([FromBody] CreateBookDto book)
        {
            if (!ModelState.IsValid) // TODO annotate model
            {
                return BadRequest(ModelState);
            }

            var newBook = await _bookService.AddBook(book);

            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book is null)
            {
                return NotFound();
            }

            await _bookService.DeleteBook(id);

            return NoContent();
        }
    }
}
