using System.ComponentModel.DataAnnotations;

namespace Entities;

public class TodoItem
{
    [Key]
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}