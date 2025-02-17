using Microsoft.EntityFrameworkCore;
using SecureToDoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoSecureApp.Data;

namespace SecureToDoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllTasksAsync() =>
            await _context.TodoItems.ToListAsync();

        public async Task<TodoItem> GetTaskByIdAsync(int id) =>
            await _context.TodoItems.FindAsync(id);

        public async Task AddTaskAsync(TodoItem task)
        {
            _context.TodoItems.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TodoItem task)
        {
            _context.TodoItems.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.TodoItems.FindAsync(id);
            if (task != null)
            {
                _context.TodoItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
