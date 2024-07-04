using Book_Library_Manager.Core.Models.DTOs;
using Book_Library_Manager.Data.Repositories;
using Book_Library_Manager.Interfaces;

namespace Book_Library_Manager.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> AddBook(CreateBookDto book)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> CheckOutBook(Guid id, string borrower)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBookById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> ReturnBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> SearchBooks(string query)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> UpdateBook(Guid id, UpdateBookDto book)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> UpdateReadingProgress(Guid id, float progress)
        {
            throw new NotImplementedException();
        }
    }
}
