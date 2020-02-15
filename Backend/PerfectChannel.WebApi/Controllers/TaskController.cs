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
            return Ok(todoItems);
        }

        // GET: api/Task/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await _todoService.GetTodoItemAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            var added = _todoService.Add(todoItem);

            if (added)
            {
                return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
            }
            return BadRequest();
        }
    }
}