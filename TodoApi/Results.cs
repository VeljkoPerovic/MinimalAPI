//using Microsoft.EntityFrameworkCore;
//using TodoApi;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//var app = builder.Build();

//var todoItems = app.MapGroup("/todoitems");

//todoItems.MapGet("/", async (TodoDb db) =>
//    await db.Todos.ToListAsync());

//todoItems.MapGet("/complete", async (TodoDb db) =>
//    await db.Todos.Where(t => (bool)t.IsComplete!).ToListAsync());

//todoItems.MapGet("/{id}", async (int id, TodoDb db) =>
//    await db.Todos.FindAsync(id)
//        is Todo todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

//todoItems.MapPost("/", async (Todo todo, TodoDb db) =>
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();

//    return Results.Created($"/todoitems/{todo.Id}", todo);
//});

//todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDb db) =>
//{
//    var todo = await db.Todos.FindAsync(id);

//    if (todo is null) return Results.NotFound();

//    todo.Name = inputTodo.Name;
//    todo.IsComplete = inputTodo.IsComplete;

//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});
//todoItems.MapDelete("/{id}", async (int? id, TodoDb db) =>
//{
//    var todo = await db.Todos.FirstOrDefaultAsync(t => t.Id == id);
//    if (todo != null)
//    {
//        db.Todos.Remove(todo);
//        await db.SaveChangesAsync();
//        return Results.NoContent();
//    }

//    return Results.NotFound();

//});


//app.Run();