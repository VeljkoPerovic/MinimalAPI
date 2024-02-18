using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiStructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/todoitems", todoItemsEndpoints.GetAll);

app.MapGet("/todoitems/complete", todoItemsEndpoints.GetComplete);

app.MapGet("/todoitems/{id}", todoItemsEndpoints.GetOne);

app.MapPost("/todoitems", todoItemsEndpoints.Create);

app.MapPut("/todoitems/{id}", todoItemsEndpoints.Update);

app.MapDelete("/todoitems/{id}", todoItemsEndpoints.Delete);



app.Run();

