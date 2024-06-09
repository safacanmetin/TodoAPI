using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoApiClient.Models;

namespace TodoApiClient
{
    public class TodoClient
    {
        private readonly HttpClient _httpClient;

        public TodoClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        private async Task<HttpResponseMessage> SendRequest(HttpMethod method, string requestUri, object? content = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri);
            if (content != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }
            return await _httpClient.SendAsync(request);
        }

        private async Task<T> ReadResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }


        public async Task<IEnumerable<TodoItem>> GetAllTodos()
        {
            HttpResponseMessage response = await SendRequest(HttpMethod.Get, "");
            return await ReadResponse<IEnumerable<TodoItem>>(response);
        }

        public async Task<TodoItem> GetTodoById(int id)
        {
            HttpResponseMessage response = await SendRequest(HttpMethod.Get, id.ToString());
            return await ReadResponse<TodoItem>(response);
        }

        public async Task CreateTodo(TodoItem todoItem)
        {
            await SendRequest(HttpMethod.Post, "", todoItem);
        }

        public async Task UpdateTodo(TodoItem todoItem)
        {
            await SendRequest(HttpMethod.Put, todoItem.Id.ToString(), todoItem);
        }

        public async Task DeleteTodo(int id)
        {
            await SendRequest(HttpMethod.Delete, id.ToString());
        }


    }



}
