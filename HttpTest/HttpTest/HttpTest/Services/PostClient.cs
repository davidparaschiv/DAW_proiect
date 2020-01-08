using HttpTest.Models;
using HttpTest.Requests;
using HttpTest.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest.Services
{
    public class PostClient
    {
        public HttpClient Client { get; }

        public PostClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44316/api/post/");

            Client = client;
        }

        // get posts feed from user ID (i.e. ID of logged in user)
        public async Task<List<Post>> GetFeedOfPosts(string id)
        {
            var response = await Client.GetAsync("getFollowersPosts/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Post>>(stringContent);
            return result;
        }

        public async Task<List<Post>> GetMyPosts(string id)
        {
            var response = await Client.GetAsync("getMyPosts/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Post>>(stringContent);
            return result;
        }

        public async Task<bool> CreatePostAsync(NewPostViewModel model, string idOfLoggedInUser)
        {
            var generalPostRequest = new GeneralPostRequest()
            {
                NameOfTheShow = model.NameOfTheShow,
                Opinion = model.Opinion,
                RatingValue = model.RatingValue,
                ShowType = model.ShowType,
                Date = DateTime.Now,
                IdOfProfile = idOfLoggedInUser
            };

            var json = JsonConvert.SerializeObject(generalPostRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("add", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Post>(stringContent);

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<Post> Details(string idOfPost)
        {
            var response = await Client.GetAsync("details/" + idOfPost);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Post>(stringContent);
            return result;
        }

        public async Task<bool> Remove(string idOfPost)
        {
            var response = await Client.DeleteAsync("delete/" + idOfPost);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Post>(stringContent);

            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}
