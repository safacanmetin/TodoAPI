using TodoAPI.Models;

namespace TodoAPI
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.Todos;
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task Add(TodoItem todoItem)
        {
            _context.Todos.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoItem todoItem)
        {
            _context.Todos.Update(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoItem = await _context.Todos.FindAsync(id);
            if (todoItem != null)
            {
                _context.Todos.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }

}
