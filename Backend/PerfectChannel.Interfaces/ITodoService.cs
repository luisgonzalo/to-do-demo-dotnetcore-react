using PerfectChannel.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Interfaces
{
    public interface ITodoService
    {
        bool Add(TodoItem todoItem);

        bool ChangeStatus(int todoItemId, bool isComplete);
        
        Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
    }
}
