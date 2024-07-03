using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Library_Manager.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0bc1b3da-bdda-4886-8ea7-7e8a05f5e7e0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2a84cd60-b527-4b00-8be9-7e89e24646eb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("35d8ef1e-a239-428a-ab2f-70dc6b7d6f37"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("53ab61ef-3033-4310-a01b-9a7e320d243c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6e371271-478e-48a4-8483-706ef9182239"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("86683d0b-6ef5-4d0f-89e5-655fdb920605"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a58c7550-8641-455a-a3c6-bd9eef479e89"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b0243205-b3e8-4d1a-b344-c981de69587c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c886d7c4-d79d-4a82-aec5-232d6cdac8b7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d2865ede-8a82-465c-a811-0811897685e4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e36604da-8649-47ab-8d7c-4262ee68a372"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ec123f55-9b11-4e08-9e00-7e79a17b8485"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowDate", "BorrowedBy", "Genre", "ISBN", "PublicationYear", "ReadingProgress", "Title" },
                values: new object[,]
                {
                    { new Guid("01b28c80-5d08-4ba8-bfcf-530e14eb1210"), "Steve McConnell", null, null, "Software Development", "9780735619678", 2004, 0f, "Code Complete: A Practical Handbook of Software Construction" },
                    { new Guid("1cc74f2a-f42f-47e3-9db9-eaa8096446ff"), "Martin Fowler", null, null, "Software Development", "9780134757599", 2018, 0f, "Refactoring: Improving the Design of Existing Code" },
                    { new Guid("2297c8ec-d67c-466b-9e31-85ec120855e0"), "David Thomas, Andrew Hunt", null, null, "Software Development", "9780135957059", 2019, 0f, "The Pragmatic Programmer: Your Journey to Mastery" },
                    { new Guid("5d759bd5-322f-4146-a9b5-18d1ef3d7771"), "Robert C. Martin", null, null, "Professional Development", "9780137081073", 2011, 0f, "The Clean Coder: A Code of Conduct for Professional Programmers" },
                    { new Guid("62eb1d22-0659-4ab4-9bfc-a5c381655d32"), "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", null, null, "Software Design", "9780201633610", 1994, 0f, "Design Patterns: Elements of Reusable Object-Oriented Software" },
                    { new Guid("80c57645-ba8b-44e0-b002-db07a4150356"), "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein", null, null, "Algorithms", "9780262033848", 2009, 0f, "Introduction to Algorithms" },
                    { new Guid("82c45795-fed5-45f0-a7ac-115cda1babe1"), "Eric Evans", null, null, "Software Architecture", "9780321125217", 2003, 0f, "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { new Guid("8895e33a-48ec-406c-8412-4f60d83f0e8d"), "Martin Fowler", null, null, "Software Architecture", "9780321127426", 2002, 0f, "Patterns of Enterprise Application Architecture" },
                    { new Guid("8b4dd5bb-5e91-4db3-aa7a-5080f1534de9"), "Gayle Laakmann McDowell", null, null, "Interview Preparation", "9780984782857", 2015, 0f, "Cracking the Coding Interview" },
                    { new Guid("9419b39d-edf9-4b16-8124-8d9aeb1eac9e"), "Robert C. Martin", null, null, "Software Development", "9780132350884", 2008, 0f, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { new Guid("f817f162-0c8d-4674-84d0-2eb7fd998f7f"), "Robert C. Martin", null, null, "Agile Methodology", "9780135974445", 2002, 0f, "Agile Software Development: Principles, Patterns, and Practices" },
                    { new Guid("f9ce84a1-9679-4012-ad7d-f17e257432b4"), "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra", null, null, "Software Design", "9780596007126", 2004, 0f, "Head First Design Patterns" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("01b28c80-5d08-4ba8-bfcf-530e14eb1210"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1cc74f2a-f42f-47e3-9db9-eaa8096446ff"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2297c8ec-d67c-466b-9e31-85ec120855e0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d759bd5-322f-4146-a9b5-18d1ef3d7771"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("62eb1d22-0659-4ab4-9bfc-a5c381655d32"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("80c57645-ba8b-44e0-b002-db07a4150356"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("82c45795-fed5-45f0-a7ac-115cda1babe1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8895e33a-48ec-406c-8412-4f60d83f0e8d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8b4dd5bb-5e91-4db3-aa7a-5080f1534de9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9419b39d-edf9-4b16-8124-8d9aeb1eac9e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f817f162-0c8d-4674-84d0-2eb7fd998f7f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f9ce84a1-9679-4012-ad7d-f17e257432b4"));

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
    }
}
