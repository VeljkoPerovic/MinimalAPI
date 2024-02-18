using Microsoft.EntityFrameworkCore;
using MinimalApiStructure;

internal static class todoItemsEndpoints
{
    public static async Task<IResult> GetAll(TodoDb db)
    {
        return TypedResults.Ok(await db.Todos.ToArrayAsync());
    }

    public static async Task<IResult> GetComplete(TodoDb db)
    {
        return TypedResults.Ok(await db.Todos.Where(t => (bool)t.IsComplete!).ToListAsync());
    }

    public static async Task<IResult> GetOne(TodoDb db, int id)
    {
        return TypedResults.Ok(await db.Todos.FirstOrDefaultAsync(t => t.Id == id));
    }

    public static async Task<IResult> Create(MinimalApiStructure.Todo todo, TodoDb db)
    {
        db.Todos.Add(todo);
        await db.SaveChangesAsync();
        return TypedResults.Created("/todoitems/{id}", todo);
    }


    public static async Task<IResult> Update(int id, MinimalApiStructure.Todo inputTodo, TodoDb db)
    {
        var todo = await db.Todos.FindAsync(id);
        if (todo == null)
        {
            return TypedResults.NotFound();
        }

        todo.Name = inputTodo.Name;
        todo.IsComplete = inputTodo.IsComplete;

        await db.SaveChangesAsync();

        return TypedResults.NoContent();

    }

    public static async Task<IResult> Delete(int id, TodoDb db)
    {
    if (await db.Todos.FindAsync(id) is Todo todo)
       {
            db.Todos.Remove(todo);      
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
       }

       return TypedResults.NotFound();
    }


}