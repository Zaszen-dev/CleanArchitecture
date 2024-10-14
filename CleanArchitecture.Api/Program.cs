using CleanArchitecture.Api.SerilogEnrichers;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure.Repositories;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Host.UseSerilog((context, config) =>
	config.ReadFrom.Configuration(context.Configuration)
		.Enrich.With(new ThreadPriorityEnricher())
		.Enrich.FromLogContext()
		.Enrich.WithThreadId()
);
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependencies();
builder.Services.AddSingleton<IPostRepository, InMemoryPostRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();