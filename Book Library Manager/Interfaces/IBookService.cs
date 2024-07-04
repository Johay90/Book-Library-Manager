using Book_Library_Manager.Core.Models.DTOs;

namespace Book_Library_Manager.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooks();
        public Task<BookDto> GetBookById(Guid Id);
        public Task<BookDto> AddBook(CreateBookDto book);
        public Task<BookDto> UpdateBook(Guid id, UpdateBookDto book);
        public Task DeleteBook(Guid Id);
        public Task<IEnumerable<BookDto>> SearchBooks(string query);
        public Task<BookDto> CheckOutBook(Guid id, string borrower);
        public Task<IEnumerable<BookDto>> ReturnBook(Guid id);
        public Task<BookDto> UpdateReadingProgress(Guid id, float progress);
    }
}
