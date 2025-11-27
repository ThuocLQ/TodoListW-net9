using Entities;
using Usecases;

namespace Infratructure;

public class InmemoryTodoItemRepository : ITodoItemRepository
{
    private readonly List<TodoItem> _items;
    private int _nextId = 1;
    public InmemoryTodoItemRepository()
    {
        _items = [];
    }
    
    public IEnumerable<TodoItem> GetItems()
    {
        return _items;
    }
    
    public TodoItem? GetByID(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }
    
    public void AddTodoItem(TodoItem item)
    { 
        item.Id = _nextId++;
        _items.Add(item);
    }
    
    public void DeleteTodoItem(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
    
    public void UpdateTodoItem(TodoItem? item)
    {
        var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Text = item.Text ?? existingItem.Text;
            existingItem.IsCompleted = item.IsCompleted;
        }
    }

}