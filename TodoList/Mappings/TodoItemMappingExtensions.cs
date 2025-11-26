using Entities;
using TodoList.Models;

namespace TodoList.Mappings;

public static class TodoItemMappingExtensions
{
    public static TodoItem ToDomain(this Item vm)
    {
        return new TodoItem
        {
            Id = vm.Id,
            Text = vm.Text,
            IsCompleted = vm.IsCompleted
        };
    }
    public static Item ToViewModel(this TodoItem domainItem)
    {
        return new Item
        {
            Id = domainItem.Id,
            Text = domainItem.Text,
            IsCompleted = domainItem.IsCompleted
        };
    }
}