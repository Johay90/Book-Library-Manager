using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Book_Library_Manager.Core.Models.Domain;
using Book_Library_Manager.Core.Models.DTOs;
using Book_Library_Manager.Interfaces;
using FluentValidation;

namespace Book_Library_Manager.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private IValidator<BookDto> _validator;

        public BookService(IBookRepository bookRepository, IMapper mapper, IValidator<BookDto> validator)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<BookDto>> AddBook(CreateBookDto createDto)
        {
            var bookDtoForValidation = _mapper.Map<BookDto>(createDto);

            var validationResult = await _validator.ValidateAsync(bookDtoForValidation);
            if (!validationResult.IsValid)
            {
                return Result.Invalid(validationResult.AsErrors());
            }

            var newBookEntity = _mapper.Map<Book>(createDto);
            var addedBook = await _bookRepository.AddBook(newBookEntity);

            var addedBookDto = _mapper.Map<BookDto>(addedBook);
            return Result.Success(addedBookDto);
        }

        public async Task<Result<BookDto>> CheckOutBook(Guid id, BorrowBookDto borrowDto)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book is null)
            {
                return Result.NotFound();
            }

            if (!string.IsNullOrEmpty(book.BorrowedBy))
            {
                return Result.Conflict("This book is currently borrowed by someone else.");
            }

            book.BorrowedBy = borrowDto.Borrower;
            book.BorrowDate = DateTime.UtcNow;

            await _bookRepository.UpdateBook(book);

            return Result.Success(_mapper.Map<BookDto>(book));
        }

        public async Task<Result> DeleteBook(Guid Id)
        {
            var entity = await _bookRepository.GetBookById(Id);

            if (entity is null)
            {
                return Result.NotFound();
            }

            await _bookRepository.DeleteBook(Id);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = _mapper.Map<List<BookDto>>(await _bookRepository.GetAllBooks());

            if (books.Any())
            {
                return Result.Success(books).Value;
            }
            else
            {
                return Result.NotFound();
            }

        }

        public async Task<Result<BookDto>> GetBookById(Guid Id)
        {
            var book = _mapper.Map<BookDto>(await _bookRepository.GetBookById(Id));

            if (book is not null)
            {
                return Result.Success(book).Value;
            }
            else
            {
                return Result.NotFound();
            }
        }

        public async Task<Result<BookDto>> ReturnBook(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book is null)
            {
                return Result.NotFound();
            }

            if (string.IsNullOrEmpty(book.BorrowedBy))
            {
                return Result.Invalid(new ValidationError
                {
                    ErrorMessage = "This book is not currently been borrowed",
                    ErrorCode = "400BadRequest"
                });
            }

            book.BorrowedBy = String.Empty;
            book.BorrowDate = null;
            book.ReadingProgress = 0;

            await _bookRepository.UpdateBook(book);

            return Result.Success(_mapper.Map<BookDto>(book));
        }

        public async Task<Result<IEnumerable<BookDto>>> SearchBooks(string query)
        {
            var books = await _bookRepository.SearchBooks(query);

            if (!books.Any())
            {
                return Result.NotFound();
            }

            var result = _mapper.Map<IEnumerable<BookDto>>(books);

            return Result.Success(result);
        }

        public async Task<Result<BookDto>> UpdateBook(Guid id, UpdateBookDto updateDto)
        {
            var existingBook = await _bookRepository.GetBookById(id);
            if (existingBook is null)
            {
                return Result.NotFound();
            }

            var bookDtoForValidation = _mapper.Map<BookDto>(updateDto);

            var validationResult = await _validator.ValidateAsync(bookDtoForValidation);
            if (!validationResult.IsValid)
            {
                return Result.Invalid(validationResult.AsErrors());
            }

            _mapper.Map(updateDto, existingBook);

            await _bookRepository.UpdateBook(existingBook);

            var updatedBookDto = _mapper.Map<BookDto>(existingBook);
            return Result.Success(updatedBookDto);
        }

        public async Task<Result<BookDto>> UpdateReadingProgress(Guid id, float progress)
        {

            var existingBook = await _bookRepository.GetBookById(id);

            if (existingBook is null)
            {
                return Result.NotFound();
            }

            existingBook.ReadingProgress = progress;

            await _bookRepository.UpdateBook(existingBook);

            var updatedBookDto = _mapper.Map<BookDto>(existingBook);

            return Result.Success(updatedBookDto);
        }
    }
}
