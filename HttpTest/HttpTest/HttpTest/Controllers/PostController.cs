using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpTest.Models;
using HttpTest.Services;
using HttpTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpTest.Controllers
{
    public class PostController : Controller
    {
        private PostClient _postClient;
        private readonly ILogger<PostController> _logger;
        private readonly ProfileController _profileController;

        public PostController(ILogger<PostController> logger, PostClient postClient, ProfileController profileController)
        {
            _logger = logger;
            _postClient = postClient;
            _profileController = profileController;
        }

        public async Task<List<Post>> GetFeedOfPosts()
        {
            var id = await _profileController.GetIdOfLoggedInUser();

            return await _postClient.GetFeedOfPosts(id);
        }

        public async Task<List<Post>> GetMyPosts()
        {
            var id = await _profileController.GetIdOfLoggedInUser();

            return await _postClient.GetMyPosts(id);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        public IActionResult NewPostSuccess()
        {
            return View();
        }

        public IActionResult NewPostFail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewPostViewModel model)
        {
            var idOfLoggedInUser = await _profileController.GetIdOfLoggedInUser();
            var success = await _postClient.CreatePostAsync(model, idOfLoggedInUser);

            if (success == true)
            {
                return RedirectToAction("NewPostSuccess", "Post");
            }
            else
            {
                return RedirectToAction("NewPostFail", "Post");
            }
        }

        public async Task<Post> Details(string idOfPost)
        {
            return await _postClient.Details(idOfPost);
        }

        public IActionResult My()
        {
            return View();
        }

        public async Task<IActionResult> Remove(string idOfPost)
        {
            var success = await _postClient.Remove(idOfPost);

            if (success == true)
            {
                return RedirectToAction("RemoveSuccess", "Post");
            }

            return RedirectToAction("RemoveFail", "Post");
        }

        public IActionResult RemoveSuccess()
        {
            return View();
        }

        public IActionResult RemoveFail()
        {
            return View();
        }
    }
}