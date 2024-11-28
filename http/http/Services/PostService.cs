using http.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace http.Services
{
    internal class PostService
    {
        private HttpClient httpClient;
        private Post post;
        private ObservableCollection<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions;
        Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

        public PostService()  
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Post>> GetPostAsync() 
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, jsonSerializerOptions); //vai pegar o content e passar pelos filtros definidos no serializer options acima
                }
            }
            catch
            {

            }
            return posts;
        }

        public async Task<Post> SavePostAsync(Post item)
        {
            try
            {
                string json = JsonSerializer.Serialize(item, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri,content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.Content);
                }

            }
            catch(Exception e) { 
                 Debug.WriteLine(e.Message);
            }   
            return post;
        }
    }
}
