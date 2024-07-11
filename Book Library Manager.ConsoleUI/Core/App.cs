using Book_Library_Manager.ConsoleUI.Enums;
using Book_Library_Manager.ConsoleUI.Services;
using Book_Library_Manager.ConsoleUI.UI;

namespace Book_Library_Manager.ConsoleUI.Core;

public class App
{
    private APIService _service;
    private ConnectionHelper _connectionHelper;
    private bool _appRunning = true;
    private const string BASEURL = "https://localhost:7081";

    public App()
    {
        _service = new APIService(BASEURL);
        _connectionHelper = new ConnectionHelper(BASEURL, 10);
    }

    public async Task Run()
    {
        while (_appRunning && await _connectionHelper.ValidConnection())
        {
            var option = UserInput.MenuSelection();
            switch (option)
            {
                case MenuOptions.ViewAllBooks:
                    break;
                case MenuOptions.ViewBook:
                    break;
                case MenuOptions.SearchBooks:
                    break;
                case MenuOptions.AddBook:
                    break;
                case MenuOptions.UpdateBook:
                    break;
                case MenuOptions.UpdateReadingProgress:
                    break;
                case MenuOptions.BorrowBook:
                    break;
                case MenuOptions.ReturnBook:
                    break;
                case MenuOptions.DeleteBook:
                    break;
                case MenuOptions.Exit:
                    break;
            }
        }
    }
}

