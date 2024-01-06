using BlazorCrud.Data;
using BlazorCrud.Entities;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Services;

public class GameDataService : IGameService
{
    private readonly DataContext _dataContext;

    public GameDataService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<GameDto>> GetAllAsync()
    {
        await Task.Delay(2000);
        return await _dataContext.Games
            .Select(x => new GameDto()
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<GameDto> AddGameAsync(GameDto dto)
    {
        var game = new Game()
        {
            Name = dto.Name
        };
        await _dataContext.Games.AddAsync(game);
        await _dataContext.SaveChangesAsync();

        dto.Id = game.Id;
        return dto;
    }
}