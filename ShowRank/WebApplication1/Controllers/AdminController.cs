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
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpGet("details/{id}")]
        public async Task<ObjectResult> DetailsAsync([FromRoute] string id)
        {
            Admin result = await _adminServices.AdminRepository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ObjectResult> AddAsync([FromBody] GeneralAdminRequest request)
        {
            Admin result = await _adminServices.AdminRepository.CreateAsync(request.ToDTO());
            await _adminServices.CommitChanges();

            return Ok(result);
        }
    }
}
