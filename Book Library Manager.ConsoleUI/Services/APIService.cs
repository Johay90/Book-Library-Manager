using Ardalis.Result;

namespace Book_Library_Manager.ConsoleUI.Services;

public class APIService
{
    private HttpClient _httpClient;
    private APIClient _client;

    public APIService(string baseUrl)
    {
        _httpClient = new HttpClient();
        _client =  new APIClient(baseUrl, _httpClient);
    }

    public async Task<Result<ICollection<BookDto>>> GetAllBooks()
    {
        var result = await _client.GetBooksAsync();

        if (!result.Any())
        {
            return Result.NotFound();
        }

        return Result.Success(result);
    }

    
}
