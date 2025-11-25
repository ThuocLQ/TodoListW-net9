using Entities;
using Usecases;
using Infratructure;

namespace TestProject;

public class TodoListManagerTests
{
    private readonly InmemoryTodoItemRepository _repo;
    private readonly TodoListManager _manager;

    public TodoListManagerTests()
    {
        _repo = new InmemoryTodoItemRepository();
        _manager = new TodoListManager(_repo);
    }

    [Fact]
    public void GetTodoItems_ShouldReturnItems()
    {
        // Arrange
        _repo.AddTodoItem(new TodoItem { Id = 1, Text = "Test 1" });
        _repo.AddTodoItem(new TodoItem { Id = 2, Text = "Test 2" });

        // Act
        var items = _manager.GetTodoItems();

        // Assert
        Assert.Equal(2, items.Count());
    }

    [Fact]
    public void AddTodoItem_ShouldAddItemToRepository()
    {
        // Arrange
        var item = new TodoItem { Id = 3, Text = "New Item" };

        // Act
        _manager.AddTodoItem(item);

        // Assert
        var result = _repo.GetByID(3);
        Assert.NotNull(result);
        Assert.Equal("New Item", result.Text);
    }

    [Fact]
    public void MarkComplete_ShouldSetIsCompletedTrue()
    {
        // Arrange
        var item = new TodoItem { Id = 5, Text = "Task", IsCompleted = false };
        _repo.AddTodoItem(item);

        // Act
        _manager.MarkComplete(5);

        // Assert
        var updated = _repo.GetByID(5);
        Assert.True(updated.IsCompleted);
    }

    [Fact]
    public void DeleteTodoItem_ShouldRemoveItem()
    {
        // Arrange
        _repo.AddTodoItem(new TodoItem { Id = 10, Text = "Delete Me" });

        // Act
        _manager.DeleteTodoItem(10);

        // Assert
        var item = _repo.GetByID(10);
        Assert.Null(item);
    }
}
