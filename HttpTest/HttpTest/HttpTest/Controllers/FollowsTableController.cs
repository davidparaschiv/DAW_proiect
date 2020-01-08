using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpTest.Services;
using HttpTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpTest.Controllers
{
    public class FollowsTableController : Controller
    {
        private readonly ILogger<FollowsTableController> _logger;
        private FollowsTableClient _followsTableClient;

        public FollowsTableController(ILogger<FollowsTableController> logger, FollowsTableClient followsTableClient)
        {
            _logger = logger;
            _followsTableClient = followsTableClient;
        }

        public async Task<int> GetFollowersNumberAsync(string id)
        {
            return await _followsTableClient.GetFollowersNumberAsync(id);
        }

        public async Task<int> GetFollowingNumberAsync(string id)
        {
            return await _followsTableClient.GetFollowingNumberAsync(id);
        }

        public async Task<List<string>> GetFollowersAsync(string id)
        {
            return await _followsTableClient.GetFollowersAsync(id);
        }

        public async Task<List<string>> GetFollowingAsync(string id)
        {
            return await _followsTableClient.GetFollowingAsync(id);
        }

        public async Task<bool> DoesFollowAsync(string idOfTheOneWhoFollows, string idOfWhoIsBeingFollowed)
        {
            return await _followsTableClient.DoesFollowAsync(idOfTheOneWhoFollows, idOfWhoIsBeingFollowed);
        }

        public async Task<IActionResult> ApplyFollow(string idOfWhoIsBeingFollowed, string idOfTheOneWhoFollows)
        {
            bool success = await _followsTableClient.ApplyFollowAsync(idOfWhoIsBeingFollowed, idOfTheOneWhoFollows);

            var model = new ApplyFollowViewModel();
            model.FollowOperationSuccess = success;

            return View(model);
        }

        public async Task<IActionResult> ApplyUnfollow(string idOfWhoIsBeingFollowed, string idOfTheOneWhoFollows)
        {
            bool success = await _followsTableClient.ApplyUnfollowAsync(idOfWhoIsBeingFollowed, idOfTheOneWhoFollows);

            var model = new ApplyUnfollowViewModel();
            model.UnfollowOperationSuccess = success;

            return View(model);
        }
    }
}