using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.DataModel;
using PerfectChannel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TaskController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            IEnumerable<TodoItem> todoItems = await _todoService.GetAllTodoItemsAsync();

            if (todoItems == null)
            {
                return NoContent();
            }
            return new ActionResult<IEnumerable<TodoItem>>(todoItems);
        }
    }
}