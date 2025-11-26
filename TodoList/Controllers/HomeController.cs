using System.Diagnostics;
using Entities;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using Usecases;
using TodoList.Mappings;

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
        return View(new TodoListViewModel() { Items = todoItems.Select(it => new Item()
        {
            Id = it.Id,
            Text = it.Text,
            IsCompleted = false
        }) });
    }
    
    //Add
    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }
    [HttpPost]
    public IActionResult Add(Item item)
    {
        _listManager.AddTodoItem(new TodoItem(){Id =  item.Id, Text = item.Text, IsCompleted = item.IsCompleted});
        return RedirectToAction("Index");
    }
    //edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var domainItem = _listManager.GetTodoItems()
            .FirstOrDefault(x => x.Id == id);

        if (domainItem == null)
            return NotFound();

        return View(domainItem.ToViewModel());
    }
    [HttpPost]
    public IActionResult Edit(Item item)
    {
        if (!ModelState.IsValid)
            return View(item);

        _listManager.UpdateTodoItem(item.ToDomain());

        return RedirectToAction("Index");
    }
    //delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (id != null)
        {
            _listManager.DeleteTodoItem(id);
        }
        return RedirectToAction("Index");
    }
    
    //markcompleted
    [HttpPost]
    public IActionResult MarkComplete(int id)
    {
        if (id != null)
        {
            _listManager.MarkComplete(id);
        }
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}