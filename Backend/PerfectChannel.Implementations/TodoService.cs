using PerfectChannel.DataModel;
using PerfectChannel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Implementations
{
    public class TodoService : ITodoService
    {
        // in memory list, shared by all clients, lost when the backend is stopped
        private static IEnumerable<TodoItem> _todoItems = new List<TodoItem>();

        public bool Add(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public bool ChangeStatus(int todoItemId, bool isComplete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            return (new TaskFactory()).StartNew(() => _todoItems);
        }

    }
}
