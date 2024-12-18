using gamedev.Dtos;
using gamedev.Entities;

namespace gamedev.Endpoints;

public static class GamesEndpoints
{
    const string GetAllGamesEndpointName = "GetAllGames";
    const string GetGameByIdEndpointName = "GetGameById";

    private static readonly List<GameDto> games = new()
    {
        new GameDto(1, "Super Mario Bros.", "Platform game", 29.99m, new DateOnly(1985, 9, 13)),
        new GameDto(2, "The Legend of Zelda", "Action-adventure game", 49.99m, new DateOnly(1986, 2, 21)),
        new GameDto(3, "Mega Play", "Shooter game", 19.99m, new DateOnly(1987, 6, 15))
    };

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", () => games).WithName(GetAllGamesEndpointName);

        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameByIdEndpointName);

        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                Genre = dbContext.Genres.Find(newGame.GenreId),
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            GameDto gameDto = new(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);

            return Results.CreatedAtRoute(GetGameByIdEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) => {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            var removedCount = games.RemoveAll(game => game.Id == id);
            return removedCount > 0 ? Results.NoContent() : Results.NotFound();
        });

        return group;
    }
}
