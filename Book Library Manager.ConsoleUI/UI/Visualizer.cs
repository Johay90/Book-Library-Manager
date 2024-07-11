using Spectre.Console;

namespace Book_Library_Manager.ConsoleUI.UI;

public static class Visualizer
{
    public static void Header()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText("Hello")
            .LeftJustified()
            .Color(Color.Cyan1));
    }
}
