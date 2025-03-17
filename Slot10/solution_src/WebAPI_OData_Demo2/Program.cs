using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebAPI_OData_Demo2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookStore"));	
builder.Services.AddControllers().AddOData(opt => opt.Select().Count().OrderBy()
.Filter().SetMaxTop(100).AddRouteComponents("odata", GetEdmModel()));	

// Add services to the container.

builder.Services.AddControllers();
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

static IEdmModel GetEdmModel()
{
	ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
	builder.EntitySet<Book>("Books");
	builder.EntitySet<Press>("Presses");
	return builder.GetEdmModel();
}