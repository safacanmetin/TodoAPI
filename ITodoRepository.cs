using TodoAPI.Models;

namespace TodoAPI
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        Task<TodoItem> GetById(int id);
        Task Add(TodoItem todoItem);
        Task Update(TodoItem todoItem);
        Task Delete(int id);
    }

}
