using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

public class TodoItemService
{
    private readonly ApplicationContext _context;
    public TodoItemService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllTodos()
    {
        return await _context.TodoItems.OrderBy(todo => todo.Id).ToListAsync();
    }

    public async Task<TodoItem> GetTodoById(int id)
    {
        TodoItem todos = await _context.TodoItems.FirstOrDefaultAsync(todo => todo.Id.Equals(id));
        return todos;
    }

    public async Task<bool> AddTodo(TodoItem todo)
    {
        var id = _context.Add(todo);
        Console.WriteLine(id);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TodoItem> UpdateTodo(TodoItem todo)
    {
        _context.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> DeleteTodo(TodoItem todo) {
        _context.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}