using System.Diagnostics;
using Entities;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using Usecases;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TodoListManager _listManager;

    public HomeController(TodoListManager listManager ,ILogger<HomeController> logger)
    {
        _listManager  = listManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var todoItems = _listManager.GetTodoItems();
        return View(new TodoListViewModel() { Items = todoItems });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}