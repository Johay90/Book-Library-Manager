using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Library_Manager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadingProgress = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowDate", "BorrowedBy", "Genre", "ISBN", "PublicationYear", "ReadingProgress", "Title" },
                values: new object[,]
                {
                    { new Guid("0bc1b3da-bdda-4886-8ea7-7e8a05f5e7e0"), "Robert C. Martin", null, null, "Agile Methodology", "9780135974445", 2002, 0f, "Agile Software Development: Principles, Patterns, and Practices" },
                    { new Guid("2a84cd60-b527-4b00-8be9-7e89e24646eb"), "Robert C. Martin", null, null, "Software Development", "9780132350884", 2008, 0f, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { new Guid("35d8ef1e-a239-428a-ab2f-70dc6b7d6f37"), "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", null, null, "Software Design", "9780201633610", 1994, 0f, "Design Patterns: Elements of Reusable Object-Oriented Software" },
                    { new Guid("53ab61ef-3033-4310-a01b-9a7e320d243c"), "David Thomas, Andrew Hunt", null, null, "Software Development", "9780135957059", 2019, 0f, "The Pragmatic Programmer: Your Journey to Mastery" },
                    { new Guid("6e371271-478e-48a4-8483-706ef9182239"), "Gayle Laakmann McDowell", null, null, "Interview Preparation", "9780984782857", 2015, 0f, "Cracking the Coding Interview" },
                    { new Guid("86683d0b-6ef5-4d0f-89e5-655fdb920605"), "Steve McConnell", null, null, "Software Development", "9780735619678", 2004, 0f, "Code Complete: A Practical Handbook of Software Construction" },
                    { new Guid("a58c7550-8641-455a-a3c6-bd9eef479e89"), "Robert C. Martin", null, null, "Professional Development", "9780137081073", 2011, 0f, "The Clean Coder: A Code of Conduct for Professional Programmers" },
                    { new Guid("b0243205-b3e8-4d1a-b344-c981de69587c"), "Eric Evans", null, null, "Software Architecture", "9780321125217", 2003, 0f, "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { new Guid("c886d7c4-d79d-4a82-aec5-232d6cdac8b7"), "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra", null, null, "Software Design", "9780596007126", 2004, 0f, "Head First Design Patterns" },
                    { new Guid("d2865ede-8a82-465c-a811-0811897685e4"), "Martin Fowler", null, null, "Software Development", "9780134757599", 2018, 0f, "Refactoring: Improving the Design of Existing Code" },
                    { new Guid("e36604da-8649-47ab-8d7c-4262ee68a372"), "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein", null, null, "Algorithms", "9780262033848", 2009, 0f, "Introduction to Algorithms" },
                    { new Guid("ec123f55-9b11-4e08-9e00-7e79a17b8485"), "Martin Fowler", null, null, "Software Architecture", "9780321127426", 2002, 0f, "Patterns of Enterprise Application Architecture" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
