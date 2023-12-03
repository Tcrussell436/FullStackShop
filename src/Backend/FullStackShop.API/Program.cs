using FullStackShop.API;
using FullStackShop.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*
 * Application Service registration
 * Configuration of the different services used in dependency injection
 * Registered with extension methods from the respective project
 */

// FullStackShop.EF
builder.Services.ConfigureDatabase(builder.Configuration);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Will migrate in development for demo purposes
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ShopContext>();
        SeedData.AddFssSeedData(dbContext);
    }
}

app.UseHttpsRedirection();

app.MapControllers();



app.Run();