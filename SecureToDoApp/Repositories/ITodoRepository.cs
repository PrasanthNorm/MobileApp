using SecureToDoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureToDoApp.Repositories
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllTasksAsync();
        Task<TodoItem> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TodoItem task);
        Task UpdateTaskAsync(TodoItem task);
        Task DeleteTaskAsync(int id);
    }
}
