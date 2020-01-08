using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowRank.Domain.ExtensionMethods;
using ShowRank.Domain.Models;
using ShowRank.Domain.Requests;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowRank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileServices _profileServices;
        private readonly UserManager<Profile> userManager;
        private readonly SignInManager<Profile> signInManager;

        public ProfileController(IProfileServices profileServices, UserManager<Profile> userManager, SignInManager<Profile> signInManager)
        {
            _profileServices = profileServices;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("add")]
        public async Task<ObjectResult> AddAsync([FromBody] GeneralProfileRequest request)
        {
            Profile result = await _profileServices.ProfileRepository.CreateAsync(request.ToDTO());
            await _profileServices.CommitChanges();

            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<ObjectResult> DetailsAsync([FromRoute] string id)
        {
            Profile result = await _profileServices.ProfileRepository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ObjectResult> UpdateAsync([FromBody] GeneralProfileRequest request, [FromRoute] string id)
        {
            Profile result = _profileServices.ProfileRepository.Update(request.ToDTO(id));
            await _profileServices.CommitChanges();

            return Ok(result);
        }

        [HttpGet("getByMail/{mail}")]
        public async Task<ObjectResult> GetByMailAsync([FromRoute] string mail)
        {
            List<Profile> result = await _profileServices.ProfileRepository.GetByCondition(x => x.Email == mail);

            // return the one profile, or null if the email is not found in DB
            if (result.Count == 1)
            {
                return Ok(result[0]);
            } else
            {
                return Ok(null);
            }  
        }

        [HttpPost("register")]
        //public async Task<ObjectResult> RegisterAsync([FromBody] RegisterProfileRequest request)
        public async Task<ObjectResult> RegisterAsync(RegisterProfileRequest request)
        {
            // check if email already exists

            List<Profile> check = await _profileServices.ProfileRepository.GetByCondition(x => x.Email == request.Email);

            if (check.Count != 0)
            {
                return Ok("Email already exists in database");
            }

            var newUser = new Profile
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio
            };

            var result = await userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(newUser, isPersistent: true);
                return Ok("success");
            }

            var errorMessages = "";

            foreach (var error in result.Errors)
            {
                errorMessages += error.Description;
                errorMessages += "\n";
            }

            return Ok(errorMessages);
        }

        [HttpPost("logIn")]
        public async Task<ObjectResult> LogInAsync(LogInProfileRequest request)
        {
            // first boolean (true) is for login persistence
            // second boolean (false) is for not enabling account lockout on failure
            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, true, false);

            if (result.Succeeded)
            {
                return Ok("success");
            }

            return Ok("failed");
        }

        [HttpPost("logOut")]
        public async Task<ObjectResult> LogOutAsync()
        {
            await signInManager.SignOutAsync();
            return Ok("success");
        }

        [HttpGet("isSignedIn")]
        public async Task<ObjectResult> IsSignedInAsync()
        {
            if (signInManager.IsSignedIn(User))
            {
                return Ok("true");
            }

            return Ok("false");
        }

        [HttpGet("getIdOfLoggedInUser")]
        public async Task<ObjectResult> GetIdOfLoggedInUserAsync()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // map null to empty string
            if (id == null)
            {
                id = "";
            }

            return Ok(id);
        }

        [HttpPost("sendThanks")]
        public async Task<ObjectResult> SendThanksAsync(SendThanksRequest request)
        {
            // for now we don't keep track of where thanks' come from, but functionality can be extended by using request.FromId

            var profile = await _profileServices.ProfileRepository.GetByIdAsync(request.ToId);
            profile.HelpsNumber++;

            var updatedProfile = _profileServices.ProfileRepository.Update(profile);
            await _profileServices.CommitChanges();

            if (updatedProfile == null)
            {
                return Ok(false);
            }

            return Ok(true);
        }

        [HttpGet("getTopProfiles")]
        public async Task<ObjectResult> GetTopProfilesAsync()
        {
            return Ok(await _profileServices.ProfileRepository.GetTopProfilesAsync());
        }
    }
}
