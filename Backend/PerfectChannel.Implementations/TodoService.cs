using PerfectChannel.DataModel;
using PerfectChannel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectChannel.Implementations
{
    public class TodoService : ITodoService
    {
        public bool Add(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public bool ChangeStatus(int todoItemId, bool isComplete)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
