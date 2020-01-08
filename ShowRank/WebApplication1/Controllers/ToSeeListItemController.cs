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
    public class ToSeeListItemController : ControllerBase
    {
        private readonly IToSeeListItemServices _toSeeListItemServices;

        public ToSeeListItemController(IToSeeListItemServices toSeeListItemServices)
        {
            _toSeeListItemServices = toSeeListItemServices;
        }

        [HttpPost("add")]
        public async Task<ObjectResult> AddAsync([FromBody] GeneralToSeeListItemRequest request)
        {
            ToSeeListItem result = await _toSeeListItemServices.ToSeeListItemRepository.CreateAsync(request.ToDTO());
            await _toSeeListItemServices.CommitChanges();

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ObjectResult> DeleteAsync([FromRoute] string id)
        {
            ToSeeListItem customer = await _toSeeListItemServices.ToSeeListItemRepository.GetByIdAsync(id);
            _toSeeListItemServices.ToSeeListItemRepository.Delete(customer);
            await _toSeeListItemServices.CommitChanges();

            return Ok(customer);
        }

        [HttpDelete("remove/{idOfPost}/{idOfProfile}")]
        public async Task<ObjectResult> RemovePostFromProfileAsync([FromRoute] string idOfPost, [FromRoute] string idOfProfile)
        {
            List<ToSeeListItem> result = await _toSeeListItemServices.ToSeeListItemRepository.GetByCondition(x => x.IdOfPost == idOfPost && x.IdOfProfile == idOfProfile);

            if (result.Count == 0)
            {
                return Ok(null);
            }

            var toSeeListItem = result[0];

            _toSeeListItemServices.ToSeeListItemRepository.Delete(toSeeListItem);
            await _toSeeListItemServices.CommitChanges();

            return Ok(toSeeListItem);
        }

        [HttpGet("details/{id}")]
        public async Task<ObjectResult> DetailsAsync([FromRoute] string id)
        {
            ToSeeListItem result = await _toSeeListItemServices.ToSeeListItemRepository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("getItemsForProfile/{profileId}")]
        public async Task<ObjectResult> GetItemsForProfileAsync([FromRoute] string profileId)
        {
            List<ToSeeListItem> result = await _toSeeListItemServices.ToSeeListItemRepository.GetByCondition(x => x.IdOfProfile == profileId);

            return Ok(result);
        }

        [HttpGet("isPostAlreadyInList/{idOfPost}/{idOfProfile}")]
        public async Task<ObjectResult> IsPostAlreadyInListAsync([FromRoute] string idOfPost, [FromRoute] string idOfProfile)
        {
            List<ToSeeListItem> result = await _toSeeListItemServices.ToSeeListItemRepository.GetByCondition(x => x.IdOfProfile == idOfProfile && x.IdOfPost == idOfPost);

            if (result.Count != 0)
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
