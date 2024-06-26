using Khudmadad_Backend.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Ef_DataContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDb"))
);

//Automatically perform migration
//builder.Services.BuildServiceProvider().GetService<Ef_DataContext>().Database.Migrate();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/", () => "HelloWorld");

app.Run();
