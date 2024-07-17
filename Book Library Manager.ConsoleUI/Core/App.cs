using Ardalis.Result;
using Book_Library_Manager.ConsoleUI.Enums;
using Book_Library_Manager.ConsoleUI.Services;
using Book_Library_Manager.ConsoleUI.UI;

namespace Book_Library_Manager.ConsoleUI.Core;

public class App
{
    private APIClient _client;
    private ConnectionHelper _connectionHelper;
    private bool _appRunning = true;
    private const string BASEURL = "https://localhost:7081";

    public App()
    {
        _client = new APIClient(BASEURL);
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
                    var allBooksResult = _client.GetBooksAsync();

                    if (allBooksResult.Result.IsSuccess)
                    {
                        Visualizer.OutputBooks(allBooksResult.Result.Value);
                        UserInput.PressKeyToContinue();
                    }
                    else
                    {
                        if (allBooksResult.Result.IsNotFound())
                        {
                            Visualizer.Errors(new[] { allBooksResult.Result.Errors.FirstOrDefault() ?? "No books found in the library." });
                        }
                        else
                        {
                            Visualizer.Errors(allBooksResult.Result.Errors);
                        }
                        UserInput.PressKeyToContinue();
                    }

                    break;
                case MenuOptions.ViewBook:
                    var bookId = UserInput.GetId();

                    var bookResult = _client.GetBookAsync(bookId);

                    if (bookResult.Result.IsSuccess)
                    {
                        Visualizer.OutputBook(bookResult.Result.Value);
                        UserInput.PressKeyToContinue();
                    }
                    else
                    {
                        Visualizer.Errors(bookResult.Result.Errors);
                        UserInput.PressKeyToContinue();
                    }


                    break;
                case MenuOptions.SearchBooks:
                    var searchString = UserInput.GetSearchQuery();
                    var bookSearchResult = _client.SearchBooksAsync(searchString);

                    if (bookSearchResult.Result.IsSuccess)
                    {
                        Visualizer.OutputBooks(bookSearchResult.Result.Value);
                        UserInput.PressKeyToContinue();
                    }
                    else
                    {
                        if (bookSearchResult.Result.IsNotFound())
                        {
                            Visualizer.Errors(new[] { bookSearchResult.Result.Errors.FirstOrDefault() ?? "No books found in the library." });
                        }
                        else
                        {
                            Visualizer.Errors(bookSearchResult.Result.Errors);
                        }
                        UserInput.PressKeyToContinue();
                    }

                    break;
                case MenuOptions.AddBook:
                    var userBook = UserInput.AddBook();
                    var addedBookResult = _client.AddBookAsync(userBook);

                    if (addedBookResult.Result.IsSuccess)
                    {
                        UserInput.PressKeyToContinue();
                    }
                    else
                    {
                        Visualizer.Errors(addedBookResult.Result.ValidationErrors);
                        UserInput.PressKeyToContinue();
                    }

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

