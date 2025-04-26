using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concretes;
using Repositories.Concretes.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

builder.Services.AddScoped<IBrandService, BrandManager>();     //her http request bir kez olusturulur
builder.Services.AddScoped<IBrandRepository,BrandRepository>();

//AddSingleton => Uygulama basladiginda bir kez olusturulur. CAche islemleri,Config ayarlarini yoneten servisler
//AddTransiet => Her kullanimda yeni bir nesne olusturur. Hafif ve bagimsiz islemler için kullanýlýr => EmailSenderService
builder.Services.AddControllers();  // Controller servislerini 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


//uygulamayý yapýlandýrýr
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.MapControllers(); //Http isteklerini controller'lara yönlendirir.


app.Run();

