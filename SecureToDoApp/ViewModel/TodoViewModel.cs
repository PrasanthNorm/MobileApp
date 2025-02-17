using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SecureToDoApp.Model;
using SecureToDoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureToDoApp.ViewModel
{
    public partial class TodoViewModel : ObservableObject
    {
        private readonly ITodoRepository _todoRepository;

        public ObservableCollection<TodoItem> Tasks { get; } = new();

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;


      



        public TodoViewModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [RelayCommand]
        public async Task LoadTasks()
        {
            var tasks = await _todoRepository.GetAllTasksAsync();
            Tasks.Clear();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        [RelayCommand]
        public async Task AddTask()
        {
            var task = new TodoItem { Title = title, Description = description, DueDate = DateTime.Now.AddDays(1) };
            await _todoRepository.AddTaskAsync(task);
            await LoadTasks();
        }

        [RelayCommand]
        public async Task DeleteTask(TodoItem task)
        {
            await _todoRepository.DeleteTaskAsync(task.Id);
            await LoadTasks();
        }
    }
}
