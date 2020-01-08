using HttpTest.Models;
using HttpTest.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest.Services
{
    public class FollowsTableClient
    {
        public HttpClient Client { get; set; }

        public FollowsTableClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44316/api/followsTable/");

            Client = client;
        }

        public async Task<int> GetFollowersNumberAsync(string id)
        {
            var response = await Client.GetAsync("getNumberOfFollowers/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            return Int32.Parse(stringContent);
        }

        public async Task<int> GetFollowingNumberAsync(string id)
        {
            var response = await Client.GetAsync("getNumberForFollowing/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            return Int32.Parse(stringContent);
        }

        public async Task<List<string>> GetFollowersAsync(string id)
        {
            var response = await Client.GetAsync("getFollowers/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(stringContent);
            return result;
        }

        public async Task<List<string>> GetFollowingAsync(string id)
        {
            var response = await Client.GetAsync("getFollowing/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(stringContent);
            return result;
        }

        public async Task<bool> DoesFollowAsync(string idOfTheOneWhoFollows, string idOfWhoIsBeingFollowed)
        {
            var response = await Client.GetAsync("doesFollow/" + idOfTheOneWhoFollows + "/" + idOfWhoIsBeingFollowed);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            if (stringContent == "true")
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ApplyFollowAsync(string idOfWhoIsBeingFollowed, string idOfTheOneWhoFollows)
        {
            var generalFollowsTableRequest = new GeneralFollowsTableRequest()
            {
                IdOfWhoIsBeingFollowed = idOfWhoIsBeingFollowed,
                IdOfTheOneWhoFollows = idOfTheOneWhoFollows
            };

            var json = JsonConvert.SerializeObject(generalFollowsTableRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("add", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<FollowsTable>(stringContent);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ApplyUnfollowAsync(string idOfWhoIsBeingFollowed, string idOfTheOneWhoFollows)
        {
            var response = await Client.GetAsync("getFollowEntryId/" + idOfTheOneWhoFollows + "/" + idOfWhoIsBeingFollowed);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            if (stringContent == "not found")
            {
                return false;
            }

            var id = stringContent;

            var response2 = await Client.DeleteAsync("delete/" + id);
            var content2 = response2.Content;
            var stringContent2 = await content2.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<FollowsTable>(stringContent2);

            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}
