using FirstApi2.Models;
using FirstApi2.RepoLayer;
using FirstApi2.ServiceLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FirstApi2.Models.FlightBookingDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddSingleton<IContainRepo<Contain>, ContainRepo>();

builder.Services.AddTransient<IContainRepo<Contain>, ContainRepo>();
builder.Services.AddTransient<IContainService<Contain>, ContainService>();

//builder.Services.AddScoped<IContainService<Contain>, ContainService>();
//builder.Services.AddSingleton<IContainService<Contain>, ContainService>();
//builder.Logging.AddLog4Net();

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//LoggerFactory log= new LoggerFactory();
//log.AddLog4Net();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();