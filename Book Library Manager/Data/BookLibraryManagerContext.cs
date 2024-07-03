using Book_Library_Manager.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Book_Library_Manager.Data
{
    public class BookLibraryManagerContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        private IConfiguration _configuration { get; set; }

        public BookLibraryManagerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnecttion");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                    Author = "Robert C. Martin",
                    ISBN = "9780132350884",
                    PublicationYear = 2008,
                    Genre = "Software Development",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                    ISBN = "9780201633610",
                    PublicationYear = 1994,
                    Genre = "Software Design",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Pragmatic Programmer: Your Journey to Mastery",
                    Author = "David Thomas, Andrew Hunt",
                    ISBN = "9780135957059",
                    PublicationYear = 2019,
                    Genre = "Software Development",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Introduction to Algorithms",
                    Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                    ISBN = "9780262033848",
                    PublicationYear = 2009,
                    Genre = "Algorithms",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Code Complete: A Practical Handbook of Software Construction",
                    Author = "Steve McConnell",
                    ISBN = "9780735619678",
                    PublicationYear = 2004,
                    Genre = "Software Development",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Refactoring: Improving the Design of Existing Code",
                    Author = "Martin Fowler",
                    ISBN = "9780134757599",
                    PublicationYear = 2018,
                    Genre = "Software Development",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Head First Design Patterns",
                    Author = "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra",
                    ISBN = "9780596007126",
                    PublicationYear = 2004,
                    Genre = "Software Design",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Clean Coder: A Code of Conduct for Professional Programmers",
                    Author = "Robert C. Martin",
                    ISBN = "9780137081073",
                    PublicationYear = 2011,
                    Genre = "Professional Development",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Cracking the Coding Interview",
                    Author = "Gayle Laakmann McDowell",
                    ISBN = "9780984782857",
                    PublicationYear = 2015,
                    Genre = "Interview Preparation",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                    Author = "Eric Evans",
                    ISBN = "9780321125217",
                    PublicationYear = 2003,
                    Genre = "Software Architecture",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Patterns of Enterprise Application Architecture",
                    Author = "Martin Fowler",
                    ISBN = "9780321127426",
                    PublicationYear = 2002,
                    Genre = "Software Architecture",
                    ReadingProgress = 0
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Agile Software Development: Principles, Patterns, and Practices",
                    Author = "Robert C. Martin",
                    ISBN = "9780135974445",
                    PublicationYear = 2002,
                    Genre = "Agile Methodology",
                    ReadingProgress = 0
                }
            );
        }
    }
}
