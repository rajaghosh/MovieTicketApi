using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieTicketApi.DatabaseContext;
using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddScoped<IMovieTicketDbContext, MovieTicketDbContext>();
builder.Services.AddDbContext<MovieTicketDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieTicketDb")));

builder.Services.AddScoped(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));
builder.Services.AddScoped<IMovieService, MovieService>();
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

//Test.TestDB();

app.Run();
