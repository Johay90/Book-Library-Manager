using System.Net.Http.Json;
using System.Text.Json;
using Book_Library_Manager.Core.Models.DTOs;
using Ardalis.Result;

namespace Book_Library_Manager.ConsoleUI.Services;

public class APIClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public APIClient(string baseUrl)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<Result<ICollection<BookDto>>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("api/Books");
        var result = await HandleResponse<ICollection<BookDto>>(response);
        return result.IsSuccess && !result.Value.Any()
            ? Result.NotFound("No books found in the library.")
            : result;
    }

    public async Task<Result<BookDto>> GetBookAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/Books/{id}");
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result<ICollection<BookDto>>> SearchBooksAsync(string query)
    {
        var response = await _httpClient.GetAsync($"api/Books/search?query={Uri.EscapeDataString(query)}");
        var result = await HandleResponse<ICollection<BookDto>>(response);
        return result.IsSuccess && !result.Value.Any()
            ? Result.NotFound($"No books found matching the query: {query}")
            : result;
    }

    public async Task<Result<BookDto>> AddBookAsync(CreateBookDto book)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Books", book);
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result<BookDto>> UpdateBookAsync(Guid id, UpdateBookDto book)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Books/{id}", book);
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result<BookDto>> UpdateBookProgressAsync(Guid id, UpdateProgressDto progressDto)
    {
        var response = await _httpClient.PatchAsJsonAsync($"api/Books/{id}/progress", progressDto);
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result<BookDto>> BorrowBookAsync(Guid id, BorrowBookDto borrowDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Books/{id}/borrow", borrowDto);
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result<BookDto>> ReturnBookAsync(Guid id)
    {
        var response = await _httpClient.PostAsync($"api/Books/{id}/return", null);
        return await HandleResponse<BookDto>(response);
    }

    public async Task<Result> DeleteBookAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/Books/{id}");
        if (response.IsSuccessStatusCode)
            return Result.Success();
        return Result.Error($"Failed to delete book. Status: {response.StatusCode}");
    }

    private async Task<Result<T>> HandleResponse<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(content, _jsonOptions);
            return result != null ? Result.Success(result) : Result.Error("Failed to deserialize response");
        }

        var errorContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return Result.NotFound(errorContent);
        }

        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            try
            {
                var errors = JsonSerializer.Deserialize<List<ValidationError>>(errorContent, _jsonOptions);
                if (errors != null && errors.Any())
                {
                    return Result.Invalid(errors);
                }
            }
            catch
            {
                // If we can't deserialize as validation errors, fall through to general error handling
            }
        }

        return Result.Error(errorContent);
    }
}