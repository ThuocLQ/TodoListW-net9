using Entities;

namespace Usecases;

public class TodoListManager
{
   private readonly ITodoItemRepository repository;

   public TodoListManager(ITodoItemRepository repository)
   {
      this.repository = repository;
   }

   public IEnumerable<TodoItem> GetTodoItems()
   {
      return repository.GetItems();
   }
//Add
   public void AddTodoItem(TodoItem todoItem)
   {
      repository.AddTodoItem(todoItem);
   }

   public void UpdateTodoItem(TodoItem todoItem)
   {
      repository.UpdateTodoItem(todoItem);
   }
//Mark
   public void MarkComplete(int id)
   {
      var item = repository.GetByID(id);
      if (item != null)
      {
         item.IsCompleted = true;
      }
      repository.UpdateTodoItem(item);
   }
//Delete
   public void DeleteTodoItem (int id)
   {
      repository.DeleteTodoItem(id);
   }
}