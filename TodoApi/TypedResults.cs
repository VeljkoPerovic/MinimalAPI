//using Microsoft.EntityFrameworkCore;
//using System.Data;
//using TodoApi;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//var app = builder.Build();

//var todoItems = app.MapGroup("/todoitems");

//// TYPED RESULTS API 

//todoItems.MapGet("/", GetAllTodos);
//todoItems.MapGet("/complete", GetCompleteTodos);
//todoItems.MapGet("/{id}", GetTodo);
//todoItems.MapPost("/", CreateTodo);
//todoItems.MapPut("/{id}", UpdateTodo);
//todoItems.MapDelete("/{id}", DeleteTodo);

//app.Run();

//static async Task<IResult> GetAllTodos(TodoDb db)
//{
//    return TypedResults.Ok(await db.Todos.ToArrayAsync());
//};

//static async Task<IResult> GetCompleteTodos(TodoDb db)
//{
//    return TypedResults.Ok(await db.Todos.Where(t => (bool)t.IsComplete!).ToListAsync());
//};

//static async Task<IResult> GetTodo(int id, TodoDb db)
//{
//    return await db.Todos.FindAsync(id)
//       is Todo todo
//            ? TypedResults.Ok(todo)
//            : TypedResults.NotFound();
//};

//static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();
//    return TypedResults.Created("/todoitems/{id}", todo);
//};

//static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
//{
//    var todo = await db.Todos.FindAsync(id);
//    if (todo == null)
//    {
//        return TypedResults.NotFound();
//    }

//    todo.Name = inputTodo.Name;
//    todo.IsComplete = inputTodo.IsComplete;

//    await db.SaveChangesAsync();

//    return TypedResults.NoContent();
//};

//static async Task<IResult> DeleteTodo(int id, TodoDb db)
//{
//    if (await db.Todos.FindAsync(id) is Todo todo)
//    {
//        db.Todos.Remove(todo);
//        await db.SaveChangesAsync();
//        return TypedResults.NoContent();
//    }

//    return TypedResults.NotFound();
//}