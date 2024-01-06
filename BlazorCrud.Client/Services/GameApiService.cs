using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services;

public class GameApiService(HttpClient httpClient) : IGameService
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<List<GameDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GameDto> AddGameAsync(GameDto game)
    {
        throw new NotImplementedException();
    }
}