



using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("connPostgreSQL")
));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO Cerrar puertas incecesarias
builder.Services.AddCors(options =>
{
    options.AddPolicy("GetAllPolicy",
      builder =>
      {
          builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();//PUT, PATCH, GET, DELETE
      });
});


//Evita que se encicle en las referencias circulares (Estudiante tiene curso, curso tiene estudiante....) 
builder.Services
    .AddControllersWithViews().AddNewtonsoftJson(
    x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );


builder.Services
    .AddDateOnlyTimeOnlyStringConverters()
    .AddDateOnlyTimeOnlyStringConverters();

builder.Services.AddSwaggerGen(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
});


//builder.Services.AddControllers()
//        .AddJsonOptions(options =>
//        {
//            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors("GetAllPolicy");

app.MapControllers();

app.Run();

