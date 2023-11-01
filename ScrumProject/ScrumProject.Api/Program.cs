using MediatR;
using ScrumProject.Application.Members.Commands;
using ScrumProject.Domain.Members;
using ScrumProject.Domain.Products;
using ScrumProject.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(RegisterMemberCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
