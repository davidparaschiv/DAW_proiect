using Microsoft.AspNetCore.Mvc;
using ShowRank.Domain.EF;
using ShowRank.Domain.ExtensionMethods;
using ShowRank.Domain.Models;
using ShowRank.Domain.Requests;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowRank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        private readonly ShowRankDbContext _context;

        public PostController(IPostServices postServices, ShowRankDbContext context)
        {
            _postServices = postServices;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ObjectResult> AddAsync([FromBody] GeneralPostRequest request)
        {
            Post result = await _postServices.PostRepository.CreateAsync(request.ToDTO());
            await _postServices.CommitChanges();

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ObjectResult> UpdateAsync([FromBody] GeneralPostRequest request, [FromRoute] string id)
        {
            Post result = _postServices.PostRepository.Update(request.ToDTO(id));
            await _postServices.CommitChanges();

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ObjectResult> DeleteAsync([FromRoute] string id)
        {
            Post customer = await _postServices.PostRepository.GetByIdAsync(id);
            _postServices.PostRepository.Delete(customer);
            await _postServices.CommitChanges();

            return Ok(customer);
        }

        [HttpGet("getFollowersPosts/{profileId}")]
        public async Task<ObjectResult> GetFollowersPostsAsync([FromRoute] string profileId)
        {
            List<Post> result = await _postServices.PostRepository.GetFollowersPostsAsync(profileId);

            return Ok(result);
        }

        [HttpGet("getMyPosts/{profileId}")]
        public async Task<ObjectResult> GetMyPostsAsync([FromRoute] string profileId)
        {
            List<Post> result = await _postServices.PostRepository.GetMyPostsAsync(profileId);

            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<ObjectResult> DetailsAsync([FromRoute] string id)
        {
            Post result = await _postServices.PostRepository.GetByIdAsync(id);

            return Ok(result);
        }
    }
}
