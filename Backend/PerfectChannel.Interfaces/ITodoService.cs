using PerfectChannel.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectChannel.Interfaces
{
    public interface ITodoService
    {
        List<TodoItem> GetItems();

        bool Add(TodoItem todoItem);

        bool ChangeStatus(int todoItemId, bool isComplete);
    }
}
