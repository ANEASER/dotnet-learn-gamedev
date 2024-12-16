using gamedev;
using gamedev.Dtos;
using gamedev.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=games.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSqlite<GameStoreContext>(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGamesEndpoints();
app.MigrateDatabase();

app.Run();
