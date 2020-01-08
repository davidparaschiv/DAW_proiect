using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HttpTest.Models;
using HttpTest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using HttpTest.Services;

namespace HttpTest.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileClient _profileClient;
        private readonly ILogger<ProfileController> _logger;
        private readonly FollowsTableController _followsTableController;
        
        public ProfileController(ILogger<ProfileController> logger, ProfileClient profileClient, FollowsTableController followsTableController)
        {
            _logger = logger;
            _profileClient = profileClient;
            _followsTableController = followsTableController;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var statusAsString = await _profileClient.LogInAsync(model);

                if (statusAsString == "success")
                {
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var statusAsString = await _profileClient.RegisterAsync(model);
       
                if (statusAsString == "success")
                {
                    return RedirectToAction("Index", "Home");
                }

                string[] separator = { "\n" };
                var errorMessages = statusAsString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError("", errorMessage);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _profileClient.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<bool> IsSignedIn()
        {
            return await _profileClient.IsSignedIn();
        }

        public async Task<string> GetIdOfLoggedInUser()
        {
            return await _profileClient.GetIdOfLoggedInUser();
        }

        public async Task<string> GetFullNameFromUserId(string id)
        {
            return await _profileClient.GetFullNameFromUserId(id);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel model)
        {
            // auth & authr
            var isSignedIn = await _profileClient.IsSignedIn();

            if (isSignedIn == false)
            {
                return RedirectToAction("LogIn", "Profile");
            }

            // get info for profile with email = Model.email

            var profileViewModel = new ProfileViewModel();
            profileViewModel.Email = model.EmailToSearchProfileBy;

            Profile profile = await _profileClient.GetProfileFromEmailAsync(profileViewModel.Email);

            // if bad search happens, unset email field of model to display correct info on Index view
            if (profile == null)
            {
                profileViewModel.Email = null;
                return View(profileViewModel);
            }

            profileViewModel.Bio = profile.Bio;
            profileViewModel.FullName = profile.FirstName + " " + profile.LastName;
            profileViewModel.HelpsNumber = profile.HelpsNumber;
            profileViewModel.Id = profile.Id;

            profileViewModel.FollowersNumber = await _followsTableController.GetFollowersNumberAsync(profile.Id);

            profileViewModel.FollowingNumber = await _followsTableController.GetFollowingNumberAsync(profile.Id);
            
            // get IDs of followers
            List<string> IDsOfFollowers = await _followsTableController.GetFollowersAsync(profile.Id);

            // get list of strings with the following format: first_name last_name (email)
            // for every follower

            profileViewModel.Followers = new List<string>();

            foreach (var id in IDsOfFollowers)
            {
                Profile profileFollower = await _profileClient.GetProfileFromIdAsync(id);
                profileViewModel.Followers.Add(profileFollower.FirstName + " " + profileFollower.LastName + " (" + profileFollower.Email + ")");
            }

            // get IDs of following
            List<string> IDsOfFollowing = await _followsTableController.GetFollowingAsync(profile.Id);

            // get list of strings with the following format: first_name last_name (email)
            // for every following

            profileViewModel.Following = new List<string>();

            foreach (var id in IDsOfFollowing)
            {
                Profile profileFollower = await _profileClient.GetProfileFromIdAsync(id);
                profileViewModel.Following.Add(profileFollower.FirstName + " " + profileFollower.LastName + " (" + profileFollower.Email + ")");
            }

            // See if logged in user follows the profile being viewed

            var IDOfLoggedInUser = await _profileClient.GetIdOfLoggedInUser();
            profileViewModel.IsFollowedByLoggedInUser = await _followsTableController.DoesFollowAsync(IDOfLoggedInUser, profile.Id);

            // check if the logged in user searched its own profile

            if (IDOfLoggedInUser == profile.Id)
            {
                profileViewModel.IsLoggedInUser = true;
            }

            return View(profileViewModel);
        }
        
        public async Task<bool> SendThanks(string fromId, string toId)
        {
            return await _profileClient.SendThanks(fromId, toId);
        }

        public IActionResult DisplayTop()
        {
            return View();
        }

        public async Task<List<Profile>> GetTopProfiles()
        {
            return await _profileClient.GetTopProfiles();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
