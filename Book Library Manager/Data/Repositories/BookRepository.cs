using Book_Library_Manager.Core.Models.Domain;
using Book_Library_Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book_Library_Manager.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookLibraryManagerContext _context;

        public BookRepository(BookLibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await GetBookById(id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Book>> SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllBooks();

            query = query.Trim().ToLower();

            return await _context.Books
                .Where(b =>
                    EF.Functions.Like(b.Author.ToLower(), $"%{query}%") ||
                    EF.Functions.Like(b.Title.ToLower(), $"%{query}%"))
                .ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
