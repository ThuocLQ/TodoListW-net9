using Entities;

namespace Usecases;

public interface ITodoItemRepository
{
    IEnumerable<TodoItem> GetItems();
    TodoItem? GetByID(int id);
    void AddTodoItem(TodoItem item);
    void UpdateTodoItem(TodoItem? item);
    void DeleteTodoItem(int id);
}