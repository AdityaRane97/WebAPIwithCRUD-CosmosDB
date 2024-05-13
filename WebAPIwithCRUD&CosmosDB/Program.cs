using Microsoft.Azure.Cosmos;
using WebAPIwithCRUDCosmosDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton((x) =>
{
    var cosmos = new CosmosClientOptions
    {
        ApplicationName = builder.Configuration["CosmosDB:DatabaseName"],
        ConnectionMode = ConnectionMode.Direct
    };
    var logger = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
    var cosmosclient = new CosmosClient(builder.Configuration["CosmosDB:endpointurl"], builder.Configuration["CosmosDB:key"], cosmos);

    return cosmosclient;
});
builder.Services.AddScoped<IEmployerRepo, EmployerRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
