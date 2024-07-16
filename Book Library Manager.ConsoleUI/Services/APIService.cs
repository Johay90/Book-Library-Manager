using Ardalis.Result;

namespace Book_Library_Manager.ConsoleUI.Services;

public class APIService
{
    private HttpClient _httpClient;
    private APIClient _client;

    public APIService(string baseUrl)
    {
        _httpClient = new HttpClient();
        _client = new APIClient(baseUrl, _httpClient);
    }

    public async Task<Result<ICollection<BookDto>>> GetAllBooks()
    {
        try
        {
            var result = await _client.GetBooksAsync();

            if (!result.Any())
            {
                return Result.NotFound();
            }
            else
            {
                return Result.Success(result);
            }
        }
        catch (ApiException ex)
        {
            return Result.Error(ex.Message);
        }
    }

    public async Task<Result<BookDto>> GetBook(Guid id)
    {
        try
        {
            var result = await _client.GetBookAsync(id);

            if (result is null)
            {
                return Result.NotFound();
            }
            else
            {
                return Result.Success(result);
            }
        }
        catch (ApiException ex)
        {
            return Result.Error(ex.Message);
        }

    }

    public async Task<Result<ICollection<BookDto>>> Search(string query)
    {
        try
        {
            var result = await _client.SearchBooksAsync(query);

            if (!result.Any())
            {
                return Result.NotFound();
            }
            else
            {
                return Result.Success(result);
            }
        }
        catch (ApiException ex)
        {
            return Result.Error(ex.Message);
        }
    }


}
