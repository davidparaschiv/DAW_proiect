using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HttpTest.Models;
using Microsoft.AspNetCore.Authorization;
using HttpTest.Services;
using HttpTest.ViewModels;

namespace HttpTest.Controllers
{
    public class ToSeeListItemController : Controller
    {
        private readonly ILogger<ToSeeListItemController> _logger;
        private readonly ProfileController _profileController;
        private ToSeeListItemClient _toSeeListItemClient;

        public ToSeeListItemController(ILogger<ToSeeListItemController> logger, ToSeeListItemClient toSeeListItemClient, ProfileController profileController)
        {
            _logger = logger;
            _toSeeListItemClient = toSeeListItemClient;
            _profileController = profileController;
        }

        public async Task<IActionResult> Add(string idOfPost)
        {
            // TODO: check if the post is already in watch list

            var idOfLoggedInUser = await _profileController.GetIdOfLoggedInUser();

            bool isAlreadyInList = await _toSeeListItemClient.IsPostAlreadyInList(idOfPost, idOfLoggedInUser);

            if (isAlreadyInList == true)
            {
                return RedirectToAction("AddAlreadyInList", "ToSeeListItem");
            }

            var success = await _toSeeListItemClient.Add(idOfPost, idOfLoggedInUser);

            if (success == true)
            {
                return RedirectToAction("AddSuccess", "ToSeeListItem");
            }

            return RedirectToAction("AddFail", "ToSeeListItem");
        }

        public IActionResult AddSuccess()
        {
            return View();
        }

        public IActionResult AddFail()
        {
            return View();
        }

        public IActionResult AddAlreadyInList()
        {
            return View();
        }

        public IActionResult Display()
        {
            return View();
        }

        public async Task<List<ToSeeListItemViewModel>> GetListDisplayInfo()
        {
            var idOfLoggedInUser = await _profileController.GetIdOfLoggedInUser();
            return await _toSeeListItemClient.GetListDisplayInfo(idOfLoggedInUser);
        }

        public async Task<IActionResult> Remove(string idOfPost)
        {
            var idOfLoggedInUser = await _profileController.GetIdOfLoggedInUser();
            var success = await _toSeeListItemClient.Remove(idOfPost, idOfLoggedInUser);

            if (success == true)
            {
                return RedirectToAction("RemoveSuccess", "ToSeeListItem");
            }

            return RedirectToAction("RemoveFail", "ToSeeListItem");
        }

        public IActionResult RemoveSuccess()
        {
            return View();
        }

        public IActionResult RemoveFail()
        {
            return View();
        }

        public async Task<IActionResult> SendThanks(string toId)
        {
            var idOfLoggedInUser = await _profileController.GetIdOfLoggedInUser();
            var success = await _toSeeListItemClient.SendThanks(idOfLoggedInUser, toId);

            if (success == true)
            {
                return RedirectToAction("SendThanksSuccess", "ToSeeListItem");
            }

            return RedirectToAction("SendThanksFail", "ToSeeListItem");
        }

        public IActionResult SendThanksSuccess()
        {
            return View();
        }

        public IActionResult SendThanksFail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
