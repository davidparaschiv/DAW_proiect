using Microsoft.AspNetCore.Mvc;
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
    public class FollowsTableController : ControllerBase
    {
        private readonly IFollowsTableServices _followsTableServices;

        public FollowsTableController(IFollowsTableServices followsTableServices)
        {
            _followsTableServices = followsTableServices;
        }

        [HttpPost("add")]
        public async Task<ObjectResult> AddAsync([FromBody] GeneralFollowsTableRequest request)
        {
            FollowsTable result = await _followsTableServices.FollowsTableRepository.CreateAsync(request.ToDTO());
            await _followsTableServices.CommitChanges();

            return Ok(result);
        }

        [HttpGet("getNumberOfFollowers/{id}")]
        public async Task<ObjectResult> GetNumberOfFollowersAsync([FromRoute] string id)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfWhoIsBeingFollowed == id);

            return Ok(result.Count);
        }

        [HttpGet("getNumberForFollowing/{id}")]
        public async Task<ObjectResult> GetNumberForFollowingAsync([FromRoute] string id)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfTheOneWhoFollows == id);

            return Ok(result.Count);
        }

        [HttpGet("getFollowers/{id}")]
        public async Task<ObjectResult> GetFollowersAsync([FromRoute] string id)
        // returns list of string (list of IDs)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfWhoIsBeingFollowed == id);

            List<string> toReturn = new List<string>();

            foreach (var item in result)
            {
                toReturn.Add(item.IdOfTheOneWhoFollows);
            }

            return Ok(toReturn);
        }

        [HttpGet("getFollowing/{id}")]
        public async Task<ObjectResult> GetFollowingAsync([FromRoute] string id)
        // returns list of string (list of IDs)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfTheOneWhoFollows == id);

            List<string> toReturn = new List<string>();

            foreach (var item in result)
            {
                toReturn.Add(item.IdOfWhoIsBeingFollowed);
            }

            return Ok(toReturn);
        }

        [HttpGet("doesFollow/{idOfTheOneWhoFollows}/{idOfWhoIsBeingFollowed}")]
        public async Task<ObjectResult> DoesFollowAsync([FromRoute] string idOfTheOneWhoFollows, [FromRoute] string idOfWhoIsBeingFollowed)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfTheOneWhoFollows == idOfTheOneWhoFollows && x.IdOfWhoIsBeingFollowed == idOfWhoIsBeingFollowed);

            if (result.Count == 1)
            {
                return Ok("true");
            }

            return Ok("false");
        }

        [HttpGet("getFollowEntryId/{idOfTheOneWhoFollows}/{idOfWhoIsBeingFollowed}")]
        public async Task<ObjectResult> GetFollowEntryIdAsync([FromRoute] string idOfTheOneWhoFollows, [FromRoute] string idOfWhoIsBeingFollowed)
        {
            List<FollowsTable> result = await _followsTableServices.FollowsTableRepository.GetByCondition(x => x.IdOfTheOneWhoFollows == idOfTheOneWhoFollows && x.IdOfWhoIsBeingFollowed == idOfWhoIsBeingFollowed);

            if (result.Count == 1)
            {
                return Ok(result[0].Id);
            }

            return Ok("not found");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ObjectResult> DeleteAsync([FromRoute] string id)
        {
            FollowsTable followsTableEntry = await _followsTableServices.FollowsTableRepository.GetByIdAsync(id);
            _followsTableServices.FollowsTableRepository.Delete(followsTableEntry);
            await _followsTableServices.CommitChanges();

            return Ok(followsTableEntry);
        }
    }
}
