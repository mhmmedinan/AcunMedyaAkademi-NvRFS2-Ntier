using Business;
using Core.Exceptions.Extensions;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddBusinessServices();
builder.Services.AddRepositoriesServices(builder.Configuration);


//AddScoped=>  //her http request bir kez olusturulur


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
    app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

// Configure the HTTP request pipeline.

app.MapControllers(); //Http isteklerini controller'lara yönlendirir.


app.Run();

