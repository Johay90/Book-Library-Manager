using Book_Library_Manager.Core.Models.Domain;

namespace Book_Library_Manager.Interfaces;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooks();
    public Task<Book> GetBookById(Guid id);
    public Task<Book> AddBook(Book book);
    public Task<Book> UpdateBook(Book book);
    public Task<Book> UpdateBookProgress(Book book);
    public Task DeleteBook(Guid id);
    public Task<IEnumerable<Book>> SearchBooks(string query);
}
