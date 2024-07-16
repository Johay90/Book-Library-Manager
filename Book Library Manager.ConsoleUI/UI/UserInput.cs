using Book_Library_Manager.ConsoleUI.Enums;
using Book_Library_Manager.Core.Models.DTOs;
using Spectre.Console;
using System.Net.NetworkInformation;

namespace Book_Library_Manager.ConsoleUI.UI;

public static class UserInput
{
    public static MenuOptions MenuSelection()
    {
        Visualizer.Header();
        return AnsiConsole.Prompt(
             new SelectionPrompt<MenuOptions>()
                 .Title("Choose an menu option?")
                 .PageSize(10)
                 .AddChoices(Enum.GetValues<MenuOptions>()));
    }

    public static Guid GetId()
    {
        return AnsiConsole.Ask<Guid>("Type an Guid");
    }

    public static void PressKeyToContinue()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }

    public static string GetSearchQuery()
    {
        return AnsiConsole.Ask<string>("Type a search phrase for Author or Title:");
    }

    public static CreateBookDto AddBook()
    {
        var newBook = new CreateBookDto();
        newBook.Title = AnsiConsole.Ask<string>("Title of book?");
        newBook.Author = AnsiConsole.Ask<string>("Author of book?");
        newBook.ISBN = AnsiConsole.Ask<string>("ISBN?");
        newBook.PublicationYear = AnsiConsole.Ask<int>("Publication Year?");
        newBook.Genre = AnsiConsole.Ask<string>("Genre?");
        return newBook;
    }
}
