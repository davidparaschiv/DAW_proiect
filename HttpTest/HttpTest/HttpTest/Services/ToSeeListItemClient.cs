using HttpTest.Controllers;
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
    public class ToSeeListItemClient
    {
        public HttpClient Client { get; }

        private readonly ProfileController _profileController;
        private readonly PostController _postController;

        public ToSeeListItemClient(HttpClient client, ProfileController profileController, PostController postController)
        {
            client.BaseAddress = new Uri("https://localhost:44316/api/toSeeListItem/");

            Client = client;
            _profileController = profileController;
            _postController = postController;
        }

        public async Task<bool> IsPostAlreadyInList(string idOfPost, string idOfProfile)
        {
            var response = await Client.GetAsync("isPostAlreadyInList/" + idOfPost + "/" + idOfProfile);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            if (stringContent == "true")
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Add(string idOfPost, string idOfProfile)
        {
            var generalToSeeListItemRequest = new GeneralToSeeListItemRequest()
            {
                IdOfPost = idOfPost,
                IdOfProfile = idOfProfile
            };

            var json = JsonConvert.SerializeObject(generalToSeeListItemRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("add", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ToSeeListItem>(stringContent);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public async Task<List<ToSeeListItemViewModel>> GetListDisplayInfo(string idOfLoggedInUser)
        {
            var response = await Client.GetAsync("getItemsForProfile/" + idOfLoggedInUser);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ToSeeListItem>>(stringContent);

            var listDisplayInfo = new List<ToSeeListItemViewModel>();

            foreach (var toSeeListItem in result)
            {
                var toSeeListItemViewModel = new ToSeeListItemViewModel();
                Post post = await _postController.Details(toSeeListItem.IdOfPost);

                toSeeListItemViewModel.ShowName = post.NameOfTheShow;
                toSeeListItemViewModel.ShowType = post.ShowType;
                toSeeListItemViewModel.IdOfPost = post.Id;
                toSeeListItemViewModel.IdOfPosterProfile = post.IdOfProfile;
                toSeeListItemViewModel.PosterFullName = await _profileController.GetFullNameFromUserId(post.IdOfProfile);

                listDisplayInfo.Add(toSeeListItemViewModel);
            }

            return listDisplayInfo;
        }

        public async Task<bool> Remove(string idOfPost, string idOfProfile)
        {
            var response = await Client.DeleteAsync("remove/" + idOfPost + "/" + idOfProfile);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ToSeeListItem>(stringContent);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> SendThanks(string fromId, string toId)
        {
            return await _profileController.SendThanks(fromId, toId);
        }
    }
}
