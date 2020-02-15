using NLog;
using PerfectChannel.DataModel;
using PerfectChannel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Implementations
{
    public class TodoService : ITodoService
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();

        // This implementation uses an in-memory list, shared by all clients, lost when the backend is stopped
        private static List<TodoItem> _todoItems = new List<TodoItem>();

        public bool Add(TodoItem todoItem)
        {
            var added = false;
            try
            {
                if (todoItem != null && !string.IsNullOrWhiteSpace(todoItem.Description))
                {
                    todoItem.Id = GenerateNewId();
                    _todoItems.Add(todoItem);
                    added = true;
                }
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error adding to-do item");
            }
            return added;
        }

        private int GenerateNewId()
        {
            lock (_todoItems)
            {
                return _todoItems.Count == 0 ?
                    1 :
                    _todoItems.Max(item => item.Id) + 1;
            }
        }

        public bool ChangeStatus(int todoItemId, bool isComplete)
        {
            var changed = false;
            try
            {
                var todoItem = _todoItems.FirstOrDefault(item => item.Id == todoItemId);
                if (todoItem != null)
                {
                    todoItem.IsComplete = isComplete;
                    changed = true;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error changing status");
            }
            return changed;
        }

        public async Task<TodoItem[]> GetAllTodoItemsAsync()
        {
            TodoItem[] result = null;
            try
            {
                result = await Task.FromResult(_todoItems.ToArray());
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error loading items");
            }
            return result;
        }

        public async Task<TodoItem> GetTodoItemAsync(int id)
        {
            TodoItem result = null;
            try
            {
                result = await Task.FromResult(_todoItems.Find(item => item.Id == id));
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error loading item");
            }
            return result;
        }

        public void ClearList()
        {
            _todoItems.Clear();
        }
    }
}
