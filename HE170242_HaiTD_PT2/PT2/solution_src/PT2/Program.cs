using AutoMapper;
using libData;
using libData.DbSlot3;
using Microsoft.EntityFrameworkCore;
using PT2.InstrumentTypeServices;
using Slot3_CodeFirst;
using Slot3_CodeFirst.PlayerServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IInstrumentTypeService, InstrumentTypeService>();
// Add services to the container.
var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperConfig()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddDatabaseService(
    builder.Configuration.GetConnectionString("DB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
