using Ardalis.Result;
using Book_Library_Manager.Core.Models.DTOs;

namespace Book_Library_Manager.Interfaces
{
    public interface IBookService
    {
        public Task<Result<IEnumerable<BookDto>>> GetAllBooks();
        public Task<Result<BookDto>> GetBookById(Guid Id);
        public Task<Result<BookDto>> AddBook(CreateBookDto book);
        public Task<Result<BookDto>> UpdateBook(Guid id, UpdateBookDto book);
        public Task<Result> DeleteBook(Guid Id);
        public Task<Result<IEnumerable<BookDto>>> SearchBooks(string query);
        public Task<Result<BookDto>> CheckOutBook(Guid id, BorrowBookDto borrowDto);
        public Task<Result<BookDto>> ReturnBook(Guid id);
        public Task<Result<BookDto>> UpdateReadingProgress(Guid id, float progress);
    }
}
