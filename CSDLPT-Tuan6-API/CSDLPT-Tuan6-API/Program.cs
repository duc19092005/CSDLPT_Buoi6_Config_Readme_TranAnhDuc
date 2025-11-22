using CSDLPT_Tuan6_API.Context;
using CSDLPT_Tuan6_API.Ultis;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DBChangerHelper>();

builder.Services.AddCors(x => x.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddDbContext<MyDbContext1>(options => options.UseSqlServer("Your Connect String 1"));
builder.Services.AddDbContext<MyDbContext2>(options => options.UseSqlServer("Your Connect String 2"));
builder.Services.AddDbContext<MyDbContext3>(options => options.UseSqlServer("Your Connect String 3"));

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