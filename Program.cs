
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Entities;
using WebApplication2.Infrastructure.Persistence;
using WebApplication2.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy.WithOrigins("http://localhost:5173/") // Your React app origin
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()    // Allow all origins
            .AllowAnyMethod()    // Allow all HTTP methods
            .AllowAnyHeader();   // Allow all headers
    });
});




//accomodates the move of appsettings.json that holds connectionstring info from root to the Infrastructure/Configurations folder for Clean Architecture adherance.
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("Infrastructure/Configurations/appsettings.Development.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.UseCors("AllowAll");

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
