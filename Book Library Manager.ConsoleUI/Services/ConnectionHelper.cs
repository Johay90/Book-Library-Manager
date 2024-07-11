namespace Book_Library_Manager.ConsoleUI.Services;

public class ConnectionHelper
{
    private readonly HttpClient _httpClient;
    private readonly int _retries;
    private const string HEALTH_ENDPOINT = "/health";

    public ConnectionHelper(string baseUrl, int retries)
    {
        _retries = retries;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(10)
        };
    }

    public async Task<bool> ValidConnection()
    {
        for (int i = 0; i < _retries; i++)
        {
            try
            {
                if (await TryConnect())
                {
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Connection attempt {i + 1} failed: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        Console.WriteLine("Could not establish a connection after multiple attempts.");
        return false;
    }

    private async Task<bool> TryConnect()
    {
        using var response = await _httpClient.GetAsync(HEALTH_ENDPOINT);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var healthReport = System.Text.Json.JsonSerializer.Deserialize<HealthReport>(content);
            return healthReport?.Status == "Healthy";
        }
        return false;
    }
}

public class HealthReport
{
    public string Status { get; set; }
}
