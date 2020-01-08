using HttpTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpTest.Services
{
    public class AdminClient
    {
        public HttpClient Client { get; }

        public AdminClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44316/admin/");

            Client = client;
        }

        public async Task<Admin> Details(int id)
        {
            var response = await Client.GetAsync("details/1");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Admin>(stringContent);
            return result;
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            var response = await Client.GetAsync("");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Admin>>(stringContent);
            return result;
        }
    }
}
