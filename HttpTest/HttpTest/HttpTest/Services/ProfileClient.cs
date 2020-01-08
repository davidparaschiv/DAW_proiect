using HttpTest.Models;
using HttpTest.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpTest.Requests;

namespace HttpTest.Services
{
    public class ProfileClient
    {
        public HttpClient Client { get; }

        public ProfileClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44316/api/profile/");

            Client = client;
        }

        public async Task<string> RegisterAsync(RegisterViewModel model)
        {
            var registerProfileRequest = new RegisterProfileRequest()
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Bio = model.Bio
            };

            var json = JsonConvert.SerializeObject(registerProfileRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("register", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            return stringContent;
        }

        public async Task<string> LogInAsync(LogInViewModel model)
        {
            var logInProfileRequest = new LogInProfileRequest()
            {
                Email = model.Email,
                Password = model.Password
            };

            var json = JsonConvert.SerializeObject(logInProfileRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("logIn", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            return stringContent;
        }

        public async Task LogOutAsync()
        {
            var json = ""; // explicitly empty json
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync("logOut", data);
        }

        public async Task<bool> IsSignedIn()
        {
            var response =  await Client.GetAsync("isSignedIn");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            
            if (stringContent == "true")
            {
                return true;
            }

            return false;
        }

        public async Task<string> GetIdOfLoggedInUser()
        {
            var response = await Client.GetAsync("getIdOfLoggedInUser");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            return stringContent;
        }

        public async Task<Profile> GetProfileFromEmailAsync(string email)
        {
            var response = await Client.GetAsync("getByMail/" + email);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Profile>(stringContent);
            return result;
        }

        public async Task<Profile> GetProfileFromIdAsync(string id)
        {
            var response = await Client.GetAsync("details/" + id);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Profile>(stringContent);
            return result;
        }

        public async Task<string> GetFullNameFromUserId(string id)
        {
            var profile = await GetProfileFromIdAsync(id);

            if (profile == null)
            {
                return "";
            }

            return profile.FirstName + " " + profile.LastName;
        }

        public async Task<bool> SendThanks(string fromId, string toId)
        {
            var sendThanksRequest = new SendThanksRequest()
            {
                ToId = toId,
                FromId = fromId
            };

            var json = JsonConvert.SerializeObject(sendThanksRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("sendThanks", data);
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();

            if (stringContent == "true")
            {
                return true;
            }

            return false;
        }

        public async Task<List<Profile>> GetTopProfiles()
        {
            var response = await Client.GetAsync("getTopProfiles");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Profile>>(stringContent);
            return result;
        }
    }
}
