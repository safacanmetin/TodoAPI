using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAllTodos()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoById(int id)
        {
            var todoItem = await _todoRepository.GetById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoRepository.Add(todoItem);

            return CreatedAtAction("GetTodoById", new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoRepository.Update(todoItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoRepository.Delete(id);

            return NoContent();
        }
    }

}
