using System;
using System.Threading.Tasks;
using TodoApiClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TodoApiClient.Models;

partial class Program
{
    static async Task Main(string[] args)
    {
        // Replace with your actual API base URL
        string baseUrl = "http://localhost:5000/api/todos";

        var todoClient = new TodoClient(baseUrl);

        // Get all todo items
        IEnumerable<TodoItem> todoItems = await todoClient.GetAllTodos();

        // Display retrieved todo items (modify based on your TodoItem properties)
        foreach (var todoItem in todoItems)
        {
            Console.WriteLine($"Id: {todoItem.Id}, Title: {todoItem.Title}");
        }


        // Create a new todo item
        TodoItem newTodo = new TodoItem
        {
            Title = "Buy groceries",
            IsComplete = false
        };

        await todoClient.CreateTodo(newTodo);

        Console.WriteLine("New todo created!");



        // Update an existing todo (assuming you have its ID)
        int todoId = 1;

        TodoItem updatedTodo = new TodoItem
        {
            Id = todoId,
            Title = "Updated title",
            IsComplete = true
        };

        await todoClient.UpdateTodo(updatedTodo);

        Console.WriteLine("Todo updated!");



        // Delete a todo (assuming you have its ID)
        todoId = 2;

        await todoClient.DeleteTodo(todoId);

        Console.WriteLine("Todo deleted!");


    }

}
