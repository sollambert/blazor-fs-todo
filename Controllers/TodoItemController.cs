using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

[ApiController]
[Route("api/[controller]")]
public class TodoItemController : ControllerBase {
    private readonly ApplicationContext _context;
    public TodoItemController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<TodoItem> GetAllTodos()
    {
        return _context.TodoItems;
    }

    [HttpGet("{id}")]
    public async Task<TodoItem> GetTodoById(int id)
    {
        List<TodoItem> todos = await _context.TodoItems.ToListAsync();
        return todos.First(todo => {
            return todo.Id == id;
        });
    }

    [HttpPost]
    public IActionResult AddTodo(TodoItem todo)
    {
        _context.Add(todo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id}, todo);
    }

    [HttpPut]
    public IActionResult UpdateTodo(TodoItem todo, int id)
    {
        todo.Id = id;
        _context.Update(todo);
        _context.SaveChanges();
        return Ok(todo);
    }

    [HttpDelete]
    public IActionResult DeleteTodo(int id) {
        TodoItem todo = _context.TodoItems.Find(id);
        _context.Remove(todo);
        _context.SaveChanges();
        return NoContent();
    }
}