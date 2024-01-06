using BlazorCrud.Data;
using BlazorCrud.Entities;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Services;

public class GameDataService(DataContext dataContext) : IGameService
{
    public async Task<List<GameDto>> GetAllAsync()
    {
        await Task.Delay(2000);
        return await dataContext.Games
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
        await dataContext.Games.AddAsync(game);
        await dataContext.SaveChangesAsync();

        dto.Id = game.Id;
        return dto;
    }
}