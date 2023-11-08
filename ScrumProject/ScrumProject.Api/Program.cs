using MediatR;
using ScrumProject.Application.Products.Handlers.Commands;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;
using ScrumProject.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(RegisterProductCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReleaseRepository, ReleaseRepository>();
builder.Services.AddScoped<ISprintRepository, SprintRepository>();
builder.Services.AddScoped<IBackLogRepository, BackLogRepository>();


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

app.Run();
