using Book_Library_Manager.ConsoleUI.Enums;
using Spectre.Console;

namespace Book_Library_Manager.ConsoleUI.UI;

public static class UserInput
{
    public static MenuOptions MenuSelection()
    {
       return AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
                .Title("Choose an menu option?")
                .PageSize(10)
                .AddChoices(Enum.GetValues<MenuOptions>()));
    }
}
