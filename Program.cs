
//Uygulama olu�turucu
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();  // Controller servislerini 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


//uygulamay� yap�land�r�r
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.MapControllers(); //Http isteklerini controller'lara y�nlendirir.

app.Run();

