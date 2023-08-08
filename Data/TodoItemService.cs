using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

public class TodoItemController
{
    private readonly ApplicationContext _context;
    public TodoItemController(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetAllTodos()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem> GetTodoById(int id)
    {
        TodoItem todos = await _context.TodoItems.FirstOrDefaultAsync(todo => todo.Id.Equals(id));
        return todos;
    }

    public async Task<bool> AddTodo(TodoItem todo)
    {
        _context.Add(todo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TodoItem> UpdateTodo(TodoItem todo, int id)
    {
        todo.Id = id;
        _context.Update(todo);
        _context.SaveChanges();
        return todo;
    }

    public async Task<bool> DeleteTodo(TodoItem todo) {
        _context.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}