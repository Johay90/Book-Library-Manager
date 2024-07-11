using Book_Library_Manager.ConsoleUI;

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

    
}
