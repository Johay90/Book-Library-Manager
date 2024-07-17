using Ardalis.Result;
using Book_Library_Manager.Core.Models.DTOs;
using Spectre.Console;
using System.Text.Json;

namespace Book_Library_Manager.ConsoleUI.UI;

public static class Visualizer
{
    public static void Header()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText("Book Library Manager")
            .LeftJustified()
            .Color(Color.Cyan1));
    }

    public static void OutputBooks(ICollection<BookDto> books)
    {
        Header();
        var table = new Table()
            .BorderColor(Color.Cyan1)
            .Border(TableBorder.Rounded)
            .Title("[cyan1]Book Collection[/]")
            .Caption("[italic gray]Total books: " + books.Count + "[/]");

        table.AddColumn(new TableColumn("[u]Title[/]").Width(30));
        table.AddColumn(new TableColumn("[u]Author[/]").Width(20));
        table.AddColumn(new TableColumn("[u]ISBN[/]").Width(15));
        table.AddColumn(new TableColumn("[u]Year[/]").Width(6).Centered());
        table.AddColumn(new TableColumn("[u]Genre[/]").Width(20));
        table.AddColumn(new TableColumn("[u]Status[/]").Width(15));
        table.AddColumn(new TableColumn("[u]Progress[/]").Width(10).Centered());

        foreach (var book in books)
        {
            var status = book.BorrowedBy is not null
                ? $"[yellow]Borrowed[/]\n{Truncate(book.BorrowedBy, 10)}\n{book.BorrowDate:d}"
                : "[green]Available[/]";

            var progress = book.ReadingProgress > 0
                ? $"[blue]{book.ReadingProgress:F1}%[/]"
                : "[gray]Not started[/]";

            table.AddRow(
                WrapText(Truncate(book.Title, 30), 30),
                Truncate(book.Author, 20),
                $"[dim]{book.ISBN}[/]",
                book.PublicationYear.ToString(),
                WrapText(Truncate(book.Genre, 20), 20),
                status,
                progress
            );
        }

        AnsiConsole.Write(
            new Panel(table)
                .Header("Your Library")
                .BorderColor(Color.Cyan1)
                .Padding(1, 1)
        );
    }

    public static void OutputBook(BookDto book)
    {
        Header();
        var table = new Table()
            .BorderColor(Color.Cyan1)
            .Border(TableBorder.Rounded)
            .Title("[cyan1]Book Collection[/]");

        table.AddColumn(new TableColumn("[u]Title[/]").Width(30));
        table.AddColumn(new TableColumn("[u]Author[/]").Width(20));
        table.AddColumn(new TableColumn("[u]ISBN[/]").Width(15));
        table.AddColumn(new TableColumn("[u]Year[/]").Width(6).Centered());
        table.AddColumn(new TableColumn("[u]Genre[/]").Width(20));
        table.AddColumn(new TableColumn("[u]Status[/]").Width(15));
        table.AddColumn(new TableColumn("[u]Progress[/]").Width(10).Centered());


        var status = book.BorrowedBy is not null
            ? $"[yellow]Borrowed[/]\n{Truncate(book.BorrowedBy, 10)}\n{book.BorrowDate:d}"
            : "[green]Available[/]";

        var progress = book.ReadingProgress > 0
            ? $"[blue]{book.ReadingProgress:F1}%[/]"
            : "[gray]Not started[/]";

        table.AddRow(
            WrapText(Truncate(book.Title, 30), 30),
            Truncate(book.Author, 20),
            $"[dim]{book.ISBN}[/]",
            book.PublicationYear.ToString(),
            WrapText(Truncate(book.Genre, 20), 20),
            status,
            progress
        );


        AnsiConsole.Write(
            new Panel(table)
                .Header("Your Library")
                .BorderColor(Color.Cyan1)
                .Padding(1, 1)
        );
    }

     public static void Errors<T>(IEnumerable<T> errors)
    {
        Header();

        Console.Beep();
        AnsiConsole.MarkupLine("[red]Errors Occurred:[/]");

        foreach (var error in errors)
        {
            if (error is ValidationError validationError)
            {
                AnsiConsole.WriteLine($"{validationError.ErrorMessage}");
            }
            else if (error is string errorString)
            {
                if (errorString.Contains("\"status\":404"))
                {
                    AnsiConsole.WriteLine("Not Found (404)");
                }
                else if (errorString.Contains("\"status\":400"))
                {
                    AnsiConsole.WriteLine("Bad Request (400)");
                }
                else if (errorString.Contains("\"status\":500"))
                {
                    AnsiConsole.WriteLine("Internal Server Error (500)");
                }
                else
                {
                    AnsiConsole.WriteLine($"{errorString}");
                }
            }
            else
            {
                AnsiConsole.WriteLine($"{error}");
            }
        }
    }

    private static string Truncate(string value, int maxLength)
    {
        return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
    }

    private static string WrapText(string text, int width)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        var words = text.Split(' ');
        var lines = new List<string>();
        var currentLine = "";

        foreach (var word in words)
        {
            if (currentLine.Length + word.Length + 1 > width)
            {
                lines.Add(currentLine.Trim());
                currentLine = "";
            }
            currentLine += word + " ";
        }

        if (!string.IsNullOrEmpty(currentLine))
            lines.Add(currentLine.Trim());

        return string.Join("\n", lines);
    }
}