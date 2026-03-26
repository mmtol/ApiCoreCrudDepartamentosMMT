using ApiCoreCrudDepartamentosMMT.Data;
using ApiCoreCrudDepartamentosMMT.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string connSring = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentosContext>(options => options.UseSqlServer(connSring));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
app.MapOpenApi();
app.MapScalarApiReference();
app.MapGet("/", () => Results.Redirect("/scalar"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
