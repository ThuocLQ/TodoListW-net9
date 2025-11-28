using Entities;
using Microsoft.EntityFrameworkCore;
using Usecases;

namespace Infratructure;

public class EfTodoItemRepository : ITodoItemRepository
{
    private readonly TodoDbContext _db;

    public EfTodoItemRepository(TodoDbContext db)
    {
        _db = db;
    }

    public IEnumerable<TodoItem> GetItems()
    {
        return _db.TodoItems.AsNoTracking().ToList();
    }

    public TodoItem? GetByID(int id)
    {
        return _db.TodoItems.FirstOrDefault(i => i.Id == id);
    }

    public void AddTodoItem(TodoItem item)
    {
        _db.TodoItems.Add(item);
        _db.SaveChanges();
    }

    public void UpdateTodoItem(TodoItem? item)
    {
        if (item == null) return;

        _db.TodoItems.Update(item);
        _db.SaveChanges();
    }

    public void DeleteTodoItem(int id)
    {
        var item = GetByID(id);
        if (item != null)
        {
            _db.TodoItems.Remove(item);
            _db.SaveChanges();
        }
    }
}