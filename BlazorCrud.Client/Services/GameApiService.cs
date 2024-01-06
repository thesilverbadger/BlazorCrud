using System.Net.Http.Json;
using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services;

public class GameApiService(HttpClient httpClient) : IGameService
{
    public Task<List<GameDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<GameDto> AddGameAsync(GameDto game)
    {
        var response = await httpClient.PostAsJsonAsync("/api/games", game);
        return await response.Content.ReadFromJsonAsync<GameDto>();
    }

    public async Task<GameDto> GetByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"/api/games/{id}");
        return await response.Content.ReadFromJsonAsync<GameDto>();
    }

    public Task<GameDto> UpdateGameAsync(GameDto dto)
    {
        throw new NotImplementedException();
    }
}