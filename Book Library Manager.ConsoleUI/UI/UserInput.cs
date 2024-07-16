using Book_Library_Manager.ConsoleUI.Enums;
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
}
