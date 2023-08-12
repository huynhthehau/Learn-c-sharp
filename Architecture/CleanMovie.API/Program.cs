using CleanMovie.Application;
using CleanMovie.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Regiter configuration
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add data service

builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
    ,b=>b.MigrationsAssembly("CleanMovie.API")));

builder.Services.AddScoped<IMovieRepository,MovieRepository>();    
builder.Services.AddScoped<IMovieService,MovieService>();


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
