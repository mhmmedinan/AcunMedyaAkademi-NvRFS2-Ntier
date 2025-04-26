using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();

