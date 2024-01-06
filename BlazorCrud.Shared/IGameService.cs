namespace BlazorCrud.Shared;

public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();

    Task<GameDto> AddGameAsync(GameDto game);
    
    Task<GameDto> GetByIdAsync(int id);

    Task<GameDto> UpdateGameAsync(GameDto dto);
}